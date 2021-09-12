using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour    
{
    // Variables
    public GameObject panelContainer;
    public GameObject tower;
    public GameObject antennaCassegrain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeSettings()
    {
        panelContainer.SetActive(false);
    }

    public void openSettings()
    {
        panelContainer.SetActive(true);
    }

    public void createTower()
    {
        // Add to scene
        Instantiate(tower);
    }

    public void createAntenna()
    {
        var newObj = GameObject.Instantiate(antennaCassegrain, GameObject.Find("tower-1(Clone)").transform);
        newObj.transform.position = new Vector3(0, 0.08f, 0);
        // antennaCassegrain.transform.parent = GameObject.Find("tower-1(Clone)").transform;
    }
}
