using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SBtAntenna : MonoBehaviour
{

    public GameObject Antenna1;
    public GameObject Antenna2;
    public GameObject Antenna3;
    public Button BtAntenna1;
    public Button BtAntenna2;
    public Button BtAntenna3;
    public Button BtAntenna4;
    public Button BtAntenna;


    // Start is called before the first frame update
    void Start()
    {
        Button BtnAntenna1 = BtAntenna1.GetComponent<Button>();
        Button BtnAntenna2 = BtAntenna2.GetComponent<Button>();
        Button BtnAntenna3 = BtAntenna3.GetComponent<Button>();
        BtnAntenna1.onClick.AddListener(BtAntenna1OnClick);
        BtnAntenna2.onClick.AddListener(BtAntenna2OnClick);
        BtnAntenna3.onClick.AddListener(BtAntenna3OnClick);
    }

    void BtAntenna1OnClick()
    {
        Antenna1.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        Instantiate(Antenna1);
        Debug.Log("Torre1");
        BtAntenna.interactable = true;
    }

    void BtAntenna2OnClick()
    {
        Antenna2.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        Instantiate(Antenna1);
        Debug.Log("Torre1");
        BtAntenna.interactable = true;
    }

    void BtAntenna3OnClick()
    {
        Antenna3.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        Instantiate(Antenna1);
        Debug.Log("Torre1");
        BtAntenna.interactable = true;
    }

}
