using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button BtAntenna;
    public Button BtPhysicalP;
    public Button BtShowCover;

    void Start()
    {
        BtAntenna.interactable = false;
        BtPhysicalP.interactable = false;
        BtShowCover.interactable = false;
    }

    void Update()
    {
        if(BtAntenna.interactable == false) {
            BtAntenna.interactable = false;
            BtPhysicalP.interactable = false;
            BtShowCover.interactable = false;
        }
        if(BtAntenna.interactable == true) {
            BtAntenna.interactable = true;
            /*BtPhysicalP.interactable = false;
            BtShowCover.interactable = false;*/
        }
        if (BtPhysicalP.interactable == true)
        {
            BtPhysicalP.interactable = true;
            //BtShowCover.interactable = false;
        }
    }



}
