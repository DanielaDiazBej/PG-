using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaController : MonoBehaviour
{
    public string type;
    public string modulationDirection;
    public string gain;

    public string height;
    public string inclination;
    public string direction;
    public string azimut;

    public GameObject cover;

    public void showHideCover(bool value)
    {
        cover.SetActive(value);
    }
}
