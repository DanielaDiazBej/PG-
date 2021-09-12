using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camT;
    // Raycast results
    private RaycastHit hit;
    private float nextHitTime = 0.5f;
    private Vector3 Point;

    public CanvasController canvasController;
    public ServiceController serviceController;
    public ServicePropController servicePropController;
    public AntennaPropController antennaPropController;

    // The object of last tower selected
    private TowerController tempTowerSelected;
    private bool towerMode = false;
    public List<GameObject> TowersPrefab;
    public int towerSelected = 0;
    public int serviceSelected = -1;

    // The object of last antenna selected
    private AntennaController tempAntennaSelected;
    private Outline tempOutlinerAntennaSelected;
    private bool antennaMode = false;
    public List<GameObject> AntennasPrefab;
    public int antennaSelected = 0;

    private bool physicPMode = false;

    public GameObject panelPropServices;
    public GameObject panelServices;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
                    TowerController towerController = hit.collider.gameObject.GetComponent<TowerController>();
                    Outline outlineTowerController = hit.collider.gameObject.GetComponent<Outline>();

                    outlineTowerController.OutlineWidth = 3f;

                    tempTowerSelected = towerController;

                    // Show services creates in the buttons
                    serviceController.updateServicesSelected(tempTowerSelected.services[0].service, tempTowerSelected.services[1].service);
                    panelServices.SetActive(true);

                    // Enable the antenna
                    canvasController.changeBtAntenna(true);
                }

                // If the hit was with a antenna object
                if (hit.transform.tag == "Antenna" && physicPMode)
                {
                    // Disable the antenna mode
                    setPhysicPMode(false);
                    canvasController.changeBtPhysicalP(false);
                }else if (hit.transform.tag == "Antenna"){
                    // Select antenna
                    AntennaController antennaController = hit.collider.gameObject.GetComponent<AntennaController>();
                    Outline outlineAntennaController = hit.collider.gameObject.GetComponent<Outline>();

                    tempAntennaSelected = antennaController;
                    tempOutlinerAntennaSelected = outlineAntennaController;
                    tempOutlinerAntennaSelected.OutlineWidth = 2f;

                    // Send data of tower and antenna to the panel
                    antennaPropController.serviceSelected = tempTowerSelected.services[serviceSelected].service;
                    antennaPropController.typeSelected = tempAntennaSelected.type;
                    antennaPropController.assingListModulationDir();
                    antennaPropController.assingListGain();

                    // Enable the antenna
                    canvasController.changeBtPhysicalP(true);
                }
            }
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
    }

    // Called from button of physic parameters
    public void setPhysicPMode (bool value) {
        antennaMode = value;
    }
    
    // Called from service panel
    public void selectService (int value){
        if(tempTowerSelected.services[value].service == "null"){            
            servicePropController.clearData();
            servicePropController.assingListServices();
            panelPropServices.SetActive(true);
        }
        serviceSelected = value;
    }
   
    // Called from service prop panel
    public void updateTowerService (string value){
        tempTowerSelected.services[serviceSelected].service = value;
    }
    public void updateTowerFreqBand (string value){
        tempTowerSelected.services[serviceSelected].frequencyBand = value;
    }
    public void updateTowerTechnology (string value){
        tempTowerSelected.services[serviceSelected].technology = value;
    }
    public void updateTowerModulation (string value){
        tempTowerSelected.services[serviceSelected].modulation = value;
    }
    public void updateTowerPropagationModel (string value){
        tempTowerSelected.services[serviceSelected].propagationModel = value;
    }
    
    // Called from antenna prop panel
    public void updateAntennaModulationDir (string value){
        tempAntennaSelected.modulationDirection = value;
    }
    public void updateAntennaModulationGain (string value){
        tempAntennaSelected.gain = value;
    }

    // Called from physic prop panel
    public void updateAntennaHeight (string value){
        tempAntennaSelected.height = value;
        canvasController.changeBtCover(true);
    }
    public void updateAntennaInclination (string value){
        tempAntennaSelected.inclination = value;
        canvasController.changeBtCover(true);
    }
    public void updateAntennaDirection (string value){
        tempAntennaSelected.direction = value;
        canvasController.changeBtCover(true);
    }
    public void updateAntennaAzimut (string value){
        tempAntennaSelected.azimut = value;
        canvasController.changeBtCover(true);
    }

    public void showHideCover(){
        tempAntennaSelected.showHideCover(true);
        tempOutlinerAntennaSelected.OutlineWidth = 0f;
    }
}
