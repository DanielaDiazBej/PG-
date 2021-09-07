using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Button BtTower;
    public Button BtAntenna;
    public Button BtPhysicalP;
    public Button BtShowCover;

    void Start()
    {
        BtTower.interactable = true;
        BtAntenna.interactable = false;
        BtPhysicalP.interactable = false;
        BtShowCover.interactable = false;
    }

    public void changeBtTower(bool value) {
        BtTower.interactable = value;
    }

    public void changeBtAntenna(bool value) {
        BtAntenna.interactable = value;
    }

    public void changeBtPhysicalP(bool value) {
        BtPhysicalP.interactable = value;
    }

    public void changeBtCover(bool value) {
        BtShowCover.interactable = value;
    }

}
