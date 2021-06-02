using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStick : MonoBehaviour
{
    public float yPosition;
    public bool isSet;

    // Update is called once per frame
    void Update()
    {
        // RaycastHit HitInfo;
        // var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 20f);

        Vector3 forward = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(transform.position, forward * 500, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.point);
            if(isSet) { 
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
            print("There is something in front of the object!");
            yPosition = hit.point.y;
        }
    }
}
