using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ServiceController : MonoBehaviour
{

    public TextMeshProUGUI txService1;
    public Button btEditService1;
    public TextMeshProUGUI txService2;
    public Button btEditService2;

    public void updateServicesSelected (string value1, string value2)
    {
        if(value1 != "---")
        {
            txService1.text = value1;
            btEditService1.interactable = true;
        }
        else
        {
            txService1.text = "Añadir servicio";
            btEditService1.interactable = false;
        }

        if(value2 != "---")
        {
            txService2.text = value2;
            btEditService2.interactable = true;
        }
        else
        {
            txService2.text = "Añadir servicio";
            btEditService2.interactable = false;
        }
    }
}
