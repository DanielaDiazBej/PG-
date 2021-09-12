using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceController : MonoBehaviour
{

    public Text txService1;
    public Text txService2;

    public void updateServicesSelected (string value1, string value2)
    {
        if(value1 != "null")
        {
            txService1.text = value1;
        }

        if(value2 != "null")
        {
            txService2.text = value2;
        }
    }
}
