using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionController : MonoBehaviour
{
    public TextMeshProUGUI txValue;
    void Start()
    {
        txValue.text = "Selecciona un tipo de torre para crear";
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
