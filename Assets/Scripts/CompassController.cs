using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 dir;

    private void Update() {
        dir.z = playerTransform.eulerAngles.y;
        transform.localEulerAngles = dir;
    }

}
