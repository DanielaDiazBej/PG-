using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtTowers : MonoBehaviour
{
    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Tower3;
    public Button BtTower1;
    public Button BtTower2;
    public Button BtTower3;
    public Button BtAntenna;

    void Start()
    {
        Button BtnTower1 = BtTower1.GetComponent<Button>();
        Button BtnTower2 = BtTower2.GetComponent<Button>();
        Button BtnTower3 = BtTower3.GetComponent<Button>();
        BtnTower1.onClick.AddListener(BtTower1OnClick);
        BtnTower2.onClick.AddListener(BtTower2OnClick);
        BtnTower3.onClick.AddListener(BtTower3OnClick);
    }


    void BtTower1OnClick()
    {
        Tower1.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        GameObject towerInstance = Instantiate(Tower1);

        DropTower.instance.towerList.Add(towerInstance);
        DropTower.instance.TowerPrefab = towerInstance;
        DropTower.instance.selected = true;

        Debug.Log("Torre1");   
    }
    void BtTower2OnClick() {
        Tower2.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        Instantiate(Tower2);
        Debug.Log("Torre2");
        BtAntenna.interactable = true;
    }
    void BtTower3OnClick()
    {
        Tower3.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        Instantiate(Tower3);
        Debug.Log("Torre3");
        BtAntenna.interactable = true;
    }
}
