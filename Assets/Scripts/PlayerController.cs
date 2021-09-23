using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    // Camera
    public GameObject camT;

    // Raycast results
    private RaycastHit hit;
    private float nextHitTime = 0.5f;
    private Vector3 Point;

    // UI
    public GameObject panelErrorAntenna;
    public CanvasController canvasController;
    public PanelsController panelPropServices;
    public PanelsController panelServices;

    // UI Controllers
    public ServiceController serviceController;
    public ServicePropController servicePropController;
    public AntennaPropController antennaPropController;
    public PhysicPropController physicPropController;
    public InfoController infoController;
    public InstructionController instructionController;

    // The object of last tower selected
    private TowerController tempTowerSelected;
    public List<GameObject> TowersPrefab;
    public int towerSelected = 0;
    public int serviceSelected = -1;

    // The object of last antenna selected
    private Antenna tempAntennaSelected;
    private Outline tempOutlinerAntennaSelected;
    public List<GameObject> AntennasPrefab;
    public int antennaSelected = 0;

    // Modes
    private bool towerMode = false;
    private bool antennaMode = false;
    private bool physicPMode = false;

    // Save all outline of towers and antennas
    private List<Outline> towersOutlines = new List<Outline>();
    private List<Outline> antennasOutlines = new List<Outline>();

    // Update is called once per frame
    void Update()
    {    
        // Validate that don't touch the UI 
        if (!IsPointerOverUIObject())
        {                
            // listen actions and continue when touch the screen
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            {
                // Gets the X,Y point from the camera and cast a Ray
                //Ray ray = aRCamera.GetComponent<Camera>().ScreenPointToRay(Input.GetTouch(0).position);
                Ray ray = camT.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                // Cast the Ray and save the result in 'hit'
                if (Physics.Raycast(ray, out hit) && nextHitTime <= Time.time)
                {
                    // If the hit was with a ground object                
                    if (hit.transform.tag == "Ground" && towerMode)
                    {
                        // Add tower model to the ground
                        Point = hit.point;
                        Instantiate(TowersPrefab[towerSelected], Point, Quaternion.identity);
                        setTowerMode(false);                 
                    }

                    // If the hit was with a tower object                
                    if (hit.transform.tag == "Tower" && antennaMode)
                    {
                        // Add antenna model to the tower
                        Point = hit.point;
                        Instantiate(AntennasPrefab[antennaSelected], Point, Quaternion.identity);
                        // Disable antenna mode
                        setAntennaMode(false);
                        canvasController.changeBtAntenna(false);
                    }else if (hit.transform.tag == "Tower"){
                        // Deselect the las tower and antenna
                        deselectAllTowers();
                        deselectAllAntennas();

                        // Hide cover
                        if(tempAntennaSelected){                            
                            tempAntennaSelected.hideCover();
                        }

                        // Disbale buttons
                        canvasController.changeBtPhysicalP(false);
                        canvasController.changeBtAntenna(false);
                        canvasController.changeBtCover(false);

                        // Select tower
                        TowerController towerController = hit.collider.gameObject.GetComponent<TowerController>();
                        Outline outlineTowerController = hit.collider.gameObject.GetComponent<Outline>();

                        // Save outline
                        towersOutlines.Add(outlineTowerController);

                        outlineTowerController.OutlineWidth = 3f;

                        tempTowerSelected = towerController;

                        // Show services creates in the buttons
                        serviceController.updateServicesSelected(tempTowerSelected.services[0].type, tempTowerSelected.services[1].type);
                        panelServices.showHidePanel();                                                
                    }

                    // If the hit was with a antenna object
                    if (hit.transform.tag == "Antenna" && physicPMode)
                    {
                        // Disable the antenna mode
                        setPhysicPMode(false);
                        canvasController.changeBtPhysicalP(false);
                    }else if (hit.transform.tag == "Antenna"){
                        // Deselect the last antenna
                        deselectAllAntennas();
                        deselectAllTowers();

                        // Disbale buttons
                        canvasController.changeBtCover(false);

                        // Hide cover
                        if(tempAntennaSelected){                            
                            tempAntennaSelected.hideCover();
                        }

                        // Select antenna
                        Antenna antennaController = hit.collider.gameObject.GetComponent<Antenna>();
                        Outline outlineAntennaController = hit.collider.gameObject.GetComponent<Outline>();                        

                        // Valid antenna and service
                        bool validAntenna = verifyAntenna(antennaController.type); 

                        if(validAntenna)
                        {                        
                            // Save outline
                            antennasOutlines.Add(outlineAntennaController);

                            tempAntennaSelected = antennaController;
                            tempOutlinerAntennaSelected = outlineAntennaController;
                            tempOutlinerAntennaSelected.OutlineWidth = 2f;

                            // Update panel info
                            infoController.updateAntennaData(tempAntennaSelected);

                            // Send data of tower and antenna to the panel
                            antennaPropController.serviceSelected = tempTowerSelected.services[serviceSelected].type;
                            antennaPropController.typeSelected = tempAntennaSelected.type;
                            antennaPropController.assingListRadiationDir();
                            antennaPropController.assingListGain();

                            // Select the data of the antenna
                            antennaPropController.fillData(tempAntennaSelected);
                            physicPropController.fillData(tempAntennaSelected);

                            // Enable antenna button
                            canvasController.changeBtPhysicalP(true);
                            // Disable tower button
                            canvasController.changeBtTower(false);
                        } 
                        else
                        {
                            // Show panel error
                            panelErrorAntenna.SetActive(true);
                        }
                    }
                
                    if(hit.transform.tag != "Ground" && hit.transform.tag != "Tower" && hit.transform.tag != "Antenna"){
                        deselectAllTowers();
                        deselectAllAntennas();

                        // Hide cover
                        if(tempAntennaSelected){                            
                            tempAntennaSelected.hideCover();
                        }

                        // Enable tower button
                        canvasController.changeBtTower(true);
                        // Disbale buttons
                        canvasController.changeBtPhysicalP(false);
                        canvasController.changeBtAntenna(false);
                        canvasController.changeBtCover(false);
                    }           
                }
            }
        }

        // Validate the current mode
        if(physicPMode){
            instructionController.updateValue("Despliega la previsualización de la onda");
            // Show panel
            instructionController.showPanel();
        }
        else if(antennaMode){
            instructionController.updateValue("Ubica la antena en la torre seleccionada");
            // Show panel
            instructionController.showPanel();
        }
        else if(towerMode)
        {
            instructionController.updateValue("Ubica la torre en una de la zonas oscuras");
            // Show panel
            instructionController.showPanel();
        }
        else
        {
            // Hide panel
            instructionController.hidePanel();
        }
    }

    // Called from buttons of towers
    public void setTowerMode (bool value) {
        towerMode = value;
    }
    public void setCurrentTower (int value) {
        towerSelected = value;
    }

    // Called from buttons of antennas
    public void setAntennaMode (bool value) {
        antennaMode = value;
    }
    public void setCurrentAntenna (int value) {
        antennaSelected = value;

        string antennaType = "Directiva";

        if(antennaSelected == 1){
            antennaType = "Omnidireccional";
        }

        bool validAntenna = verifyAntenna(antennaType);

        if(!validAntenna)
        {
            setAntennaMode(false);
            // Show panel error
            panelErrorAntenna.SetActive(true);

            // Deselect the last antenna
            deselectAllAntennas();
            deselectAllTowers();

            // Disbale buttons
            canvasController.changeBtAntenna(false);
        }
    }

    // Called from button of physic parameters
    public void setPhysicPMode (bool value) {
        antennaMode = value;
    }
    
    // Called from service panel
    public void selectService (int value){
        // Clear info controller
        infoController.clearData();

        if(tempTowerSelected.services[value].type == "---"){          
            servicePropController.clearData();
            servicePropController.assingListServices();
            panelPropServices.showHidePanel();            
        }else
        {
            // Enable the antenna
            canvasController.changeBtAntenna(true);
        }
        serviceSelected = value;

        // Update panel info
        infoController.updateTowerData(tempTowerSelected.services[serviceSelected]);
    }

    public void loadDataService (int value)
    {
        servicePropController.fillData(tempTowerSelected.services[value]);
    }
   
    // Called from service prop panel
    public void updateTowerService (string value){
        tempTowerSelected.services[serviceSelected].type = value;
        infoController.setService(value);
    }
    public void updateTowerFreqBand (string value){
        tempTowerSelected.services[serviceSelected].frequencyBand = value;
        infoController.setFrequency(value);
    }
    public void updateTowerTechnology (string value){
        tempTowerSelected.services[serviceSelected].technology = value;
        infoController.setTech(value);
    }
    public void updateTowerModulation (string value){
        tempTowerSelected.services[serviceSelected].modulation = value;
        infoController.setModulation(value);
    }
    public void updateTowerPropagationModel (string value){
        tempTowerSelected.services[serviceSelected].propagationModel = value;
        infoController.setModel(value);
    }
    
    // Called from antenna prop panel
    public void updateAntennaRadiationDir (string value){
        tempAntennaSelected.radiationDirection = value;
        infoController.setRadiationDir(value);
    }
    public void updateAntennaGain (string value){
        tempAntennaSelected.gain = value;
        infoController.setGain(value);
    }

    // Called from physic prop panel
    public void updateAntennaHeight (string value){
        tempAntennaSelected.height = value;
        canvasController.changeBtCover(true);
        infoController.setHeight(value);
    }
    public void updateAntennaInclination (string value){
        tempAntennaSelected.inclination = value;
        canvasController.changeBtCover(true);
        infoController.setInclination(value);
    }
    public void updateAntennaAzimut (string value){
        tempAntennaSelected.azimut = value;
        canvasController.changeBtCover(true);
        infoController.setAzimut(value);
    }

    // Show the cover of the wave
    public void showHideCover(){
        if(tempAntennaSelected){
            tempAntennaSelected.showHideCover();
            tempOutlinerAntennaSelected.OutlineWidth = 0f;
        }
    }

    // Delete the outline of all selections
    private void deselectAllTowers(){
        foreach (var outline in towersOutlines){
            outline.OutlineWidth = 0f;
        }
    }
    private void deselectAllAntennas(){
        foreach (var outline in antennasOutlines){
            outline.OutlineWidth = 0f;
        }
    }

    // Validate that the type of antenna is compatible with service selected
    private bool verifyAntenna(string value)
    {
        bool res = true;

        string currentService = tempTowerSelected.services[serviceSelected].type;
        if(currentService == "Punto a punto")
        {
            if(value == "Omnidireccional"){
                res = false;
            }
        }

        return res;

    }
    // Validate that the user touch the UI
    private bool IsPointerOverUIObject()
     {
         PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
         eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
         List<RaycastResult> results = new List<RaycastResult>();
         EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
         return results.Count > 0;
     }
}
