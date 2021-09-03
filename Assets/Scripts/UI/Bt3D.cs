using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bt3D : MonoBehaviour
{
    // Start is called before the first frame update
    private bool is3D = false;
    void Start()
    {
        
    }

    public void changeView() {        
        Transform camT = Camera.main.transform;
        if(is3D){
            SetXRotation(camT, 90f);
        }else{
            SetXRotation(camT, 30f);
        }

        is3D = !is3D;
    }

    private void SetXRotation(Transform t, float angle)
    {
        t.localEulerAngles = new Vector3(angle, t.localEulerAngles.y, t.localEulerAngles.z);
    }

}
