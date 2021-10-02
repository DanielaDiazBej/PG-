using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorController : MonoBehaviour
{
    public TextMeshProUGUI txValue;
    void Start()
    {
        txValue.text = "El tipo de antena seleccionada no es compatible con el servicio actual";
    }

    public void updateValue(string value)
    {
        txValue.text = value;
    }

    public void showPanel(){
        this.gameObject.SetActive(true);
    }

    public void hidePanel(){
        this.gameObject.SetActive(false);
    }
}
