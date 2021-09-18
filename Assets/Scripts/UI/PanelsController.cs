using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsController : MonoBehaviour
{
    public GameObject panel;
    private bool isActive = false;

    public void showHidePanel() {
        panel.SetActive(!isActive);
        isActive = !isActive;
    }
}
