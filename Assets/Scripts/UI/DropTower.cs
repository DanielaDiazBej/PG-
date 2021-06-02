using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTower : MonoBehaviour
{
    public static DropTower instance;
    public GameObject TowerPrefab;
    public Vector3 mouseOffset;
    public bool selected;
    public bool isSet;
    public BtTowers BtT;

    // Start is called before the first frame update
    void Start()
    {
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
            isSet = true;
            BtT.BtAntenna.interactable = true;

        }
    }
}
