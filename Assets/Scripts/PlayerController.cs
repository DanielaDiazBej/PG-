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
    public ServicePropController servicePropController;

    // The object of last tower selected
    private TowerController tempTowerSelected;
    private bool towerMode = false;
    public List<GameObject> TowersPrefab;
    public int towerSelected = 0;


    // The object of last antenna selected
    private AntennaController tempAntennaSelected;
    private bool antennaMode = false;
    public List<GameObject> AntennasPrefab;
    public int antennaSelected = 0;

    private bool physicPMode = false;

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
                    tempTowerSelected = towerController;

                    if(towerController.service == "null"){
                        panelServices.SetActive(true);
                    }

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
                    tempAntennaSelected = antennaController;

                    // Send data of tower and antenna to the panel
                    servicePropController.serviceSelected = tempTowerSelected.service;
                    servicePropController.typeSelected = tempAntennaSelected.type;
                    servicePropController.assingListFrequencyBand();

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
    public void updateTowerService (string value){
        tempTowerSelected.service = value;
    }

    // Called from service prop panel
    public void updateAntennaFreqBand (string value){
        tempAntennaSelected.frequencyBand = value;
    }
    public void updateAntennaModulation (string value){
        tempAntennaSelected.modulation = value;
    }
    public void updateAntennaModulationDir (string value){
        tempAntennaSelected.modulationDirection = value;
    }
    public void updateAntennaTechnology (string value){
        tempAntennaSelected.technology = value;
    }
    public void updateAntennaPropagationModel (string value){
        tempAntennaSelected.propagationModel = value;
    }
    public void updateAntennaModulationGain (string value){
        tempAntennaSelected.gain = value;
    }

    // Called from physic prop panel
    public void updateAntennaHeight (string value){
        tempAntennaSelected.height = value;
    }
    public void updateAntennaInclination (string value){
        tempAntennaSelected.inclination = value;
    }
    public void updateAntennaDirection (string value){
        tempAntennaSelected.direction = value;
    }
    public void updateAntennaAzimut (string value){
        tempAntennaSelected.azimut = value;
    }
}
