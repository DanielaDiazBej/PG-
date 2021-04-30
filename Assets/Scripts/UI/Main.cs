using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button BtAntenna;
    public Button BtPhysicalP;
    public Button BtShowCover;

    void Update()
    {
        BtAntenna.interactable = false;
        BtPhysicalP.interactable = false;
        BtShowCover.interactable = false;
    }

}
