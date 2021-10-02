using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnntena : MonoBehaviour
{
    public Transform antennaTarget;
    public GameObject antenna2;
    float strength = 1.5f;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Quaternion antennaTargetRotation = Quaternion.LookRotation(antennaTarget.position - transform.position);
            float str = Mathf.Min(strength * Time.deltaTime, 1);
            antenna2.transform.rotation = Quaternion.Lerp(antenna2.transform.rotation, antennaTargetRotation, str);
        }
    }

    public void activeRotation ()
    {
        active = true;
    }

}
