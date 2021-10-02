using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    public string type = "---";
    public string radiationDirection = "---";
    public string gain = "---";

    public string height = "---";
    public string inclination = "---";
    public string azimut = "---";

    public GameObject cover;

    public RotateAnntena rotateAnntena;

    public ParticleSystem coverParticle;
    private bool isShowCover = false;

    public void showHideCover()
    {
        cover.SetActive(!isShowCover);
        isShowCover = !isShowCover;
    }

    public void showCover (){
        cover.SetActive(true);
        isShowCover = true;
    }
    
    public void hideCover (){
        cover.SetActive(false);
        isShowCover = false;
    }
}
