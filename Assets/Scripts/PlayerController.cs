using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // AR Camera
    public GameObject camT;
    // Raycast results
    private RaycastHit hit;
    public float nextHitTime = 0.5f;

    private Vector3 Point;
    public GameObject prefab;

    private bool towerMode = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Run only if the is in the tower mode
        if(towerMode){
            // listen actions and continue when touch the screen
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            {
                // Gets the X,Y point from the camera and cast a Ray
                //Ray ray = aRCamera.GetComponent<Camera>().ScreenPointToRay(Input.GetTouch(0).position);
                Ray ray = camT.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                // Cast the Ray and save the result in 'hit'
                if (Physics.Raycast(ray, out hit) && nextHitTime <= Time.time)
                {
                    // If Ray hits an object with tag 'coffee'
                    if (hit.transform.tag == "Ground")
                    {
                        Point = hit.point;
                        Instantiate(prefab, Point, Quaternion.identity);
                        setTowerMode(false);

                        DropTower.instance.towerList.Add(prefab);
                        DropTower.instance.TowerPrefab = prefab;
                        DropTower.instance.selected = true;
                    }
                }
            }
        }
    }

    public void setTowerMode (bool value) {
        towerMode = value;
    }
}
