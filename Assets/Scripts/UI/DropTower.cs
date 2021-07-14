using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropTower : MonoBehaviour
{
    public static DropTower instance;
    public currentState states;
    public GameObject TowerPrefab;
    public GameObject ServicePanel;
    public Vector3 mouseOffset;
    public bool selected;
    public bool isSet;
    public BtTowers BtT;

    public List<Button> botonesUI = new List<Button>();

    [Header("Tower List")]
    [Space(5)]
    public List<GameObject> towerList = new List<GameObject>();
    public int currentTowerSelected = 0;

    // Start is called before the first frame update
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (selected && !isSet) {
            TowerPrefab.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        }
        if (selected && Input.GetMouseButton(1))
        {
            TowerPrefab.GetComponent<TowerStick>().isSet = true;
            TowerPrefab.GetComponent<TowerStick>().towerIndex = towerList.Count;
            
            isSet = true;
            //BtT.BtAntenna.interactable = true;
        }
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit)) {
                if(states == currentState.dropTower){
                    switch (hit.transform.tag)
                    {
                        case "Tower":
                            hit.transform.gameObject.GetComponent<TowerStick>().selectTower();
                            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                            ServicePanel.SetActive(true);
                        break;
                    }
                }else if (states == currentState.updateAntenna){
                    switch (hit.transform.tag)
                    {
                        case "Antenna":
                        // hit.transform.gameObject.GetComponent<TowerStick>().selectTower();
                            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                        break;
                    }
                }
            }
        }
    }

    public void updateTowers(){
        foreach (GameObject item in towerList)
        {
            item.GetComponent<TowerStick>().ArrowModel.SetActive(false);
        }
    }


    public void activateAntenna(int index){
        TowerStick tempTower = towerList[currentTowerSelected-1].GetComponent<TowerStick>();

        if(tempTower.antennasCount >= 5){
            return;
        }

        tempTower.antenasList[tempTower.antennasCount].SetActive(true);
        tempTower.antennasCount++;
    }

    public void updateStates(int index){
        switch (index)
        {
            case 0:
                states = currentState.dropAntenna;
            break;

            case 1:
                states = currentState.dropTower;
            break;

            case 2:
                states = currentState.updateAntenna;
            break;

            case 3:
                states = currentState.updateTower;
            break;
        }
    }
}

public enum currentState {
    dropTower, dropAntenna, updateTower, updateAntenna
}
