using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStick : MonoBehaviour {
    public float yPosition;
    public bool isSet;
    public bool ending;
    
    [Header("Antenna Attributes")]
    public int antennasCount = 0;
    public List<GameObject> antenasList = new List<GameObject>();

    [Header("Tower Attributes")]
    public bool isSelected = false;
    public int towerIndex;
    public GameObject ArrowModel;

    void Start(){
        for (int i = 0; i < antenasList.Count; i++) {
            antenasList[i].gameObject.SetActive(false);
        }
        ArrowModel.SetActive(false);
    }

    public void selectTower(){
        isSelected = true;
        DropTower.instance.currentTowerSelected = towerIndex;
        DropTower.instance.updateTowers();
        ArrowModel.SetActive(true);

        DropTower.instance.botonesUI[0].interactable = false;
        DropTower.instance.botonesUI[1].interactable = true;
        DropTower.instance.updateStates(2);
    }

    void Update() {
        // RaycastHit HitInfo;
        // var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 20f);

        Vector3 forward = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(transform.position, forward * 500, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity))
        {
            Vector3 objectCenter = hit.collider.gameObject.transform.position;

            if (isSet && !ending) { 
                if (hit.collider.transform.tag == "Ground") {
                    transform.localPosition = new Vector3(objectCenter.x, hit.point.y, objectCenter.z);   
                }else{
                    transform.localPosition = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                }
                
                DropTower.instance.selected = false;
                DropTower.instance.isSet = false;
                ending = true;
            }
            //print("There is something in front of the object!");
            yPosition = hit.point.y;
        }
    }
}
