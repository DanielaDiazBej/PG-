using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServicePropController : MonoBehaviour
{
    public PlayerController player;

    public Dropdown serviceDropdown;
    public Dropdown frequencyBandDropdown;
    public Dropdown techDropdown;
    public Dropdown modulationDropdown;
    public Dropdown propagationModelDropdown;

    public Button btnAccept;

    public int serviceVal, frequencyBandVal, techVal, modulationVal, propagationModelVal;

    public string serviceSelected;
    public string frequencyBandSelected;
    public string techSelected;
    public string modulationSelected;
    public string propagationModelSelected;
    // Start is called before the first frame update
    void Start()
    {
        frequencyBandDropdown.interactable = false;
        techDropdown.interactable = false;
        modulationDropdown.interactable = false;
        propagationModelDropdown.interactable = false;
        btnAccept.interactable = false;
    }

    public void clearData () {
        serviceDropdown.ClearOptions();
        frequencyBandDropdown.ClearOptions();
        techDropdown.ClearOptions();
        modulationDropdown.ClearOptions();
        propagationModelDropdown.ClearOptions();

        frequencyBandDropdown.interactable = false;
        techDropdown.interactable = false;
        modulationDropdown.interactable = false;
        propagationModelDropdown.interactable = false;
    }

    public void assingListServices()
    {
        // Clear dropdown
        serviceDropdown.ClearOptions();

        List<string> itemsServices = new List<string>() { "Selecciona una opción", "Televisión", "Punto a punto" };
        serviceDropdown.AddOptions(itemsServices);

    }
    public void selectServices (int val) 
    {
        serviceSelected = serviceDropdown.options[val].text;

        // Clear the next dropdowns
        frequencyBandDropdown.interactable = false;
        frequencyBandDropdown.ClearOptions();
        techDropdown.interactable = false;
        techDropdown.ClearOptions();
        modulationDropdown.interactable = false;
        modulationDropdown.ClearOptions();
        propagationModelDropdown.interactable = false;
        propagationModelDropdown.ClearOptions();
        
        // Enable the next dropdown
        assingListFrequencyBand();
    }
    
    public void assingListFrequencyBand()
    {
        // Clear dropdown
        frequencyBandDropdown.ClearOptions();

        if (serviceSelected == "Televisión")
        {
            List<string> itemsFB = new List<string>() { "Selecciona una opción", "470 - 614M" };
            frequencyBandDropdown.AddOptions(itemsFB);
        }
        else if (serviceSelected == "Punto a punto")
        {
            List<string> itemsFB = new List<string>() { "Selecciona una opción", "3G - 80G" };
            frequencyBandDropdown.AddOptions(itemsFB);
        }
        // Enable Dropdown
        frequencyBandDropdown.interactable = true;    
    }
    public void selectFrequencyBand (int val) 
    {
        frequencyBandSelected = frequencyBandDropdown.options[val].text;

        // Clear the next dropdowns
        techDropdown.interactable = false;
        techDropdown.ClearOptions();
        modulationDropdown.interactable = false;
        modulationDropdown.ClearOptions();
        propagationModelDropdown.interactable = false;
        propagationModelDropdown.ClearOptions();
        
        // Enable the next dropdown
        assingListTech();
    }

    public void assingListTech()
    {
        // Clear dropdown
        techDropdown.ClearOptions();

        //Televisión service
        if (frequencyBandSelected == "470 - 614M")
        {
            List<string> itemsT = new List<string>() { "Selecciona una opción", "ISDB-TB", "DVB-T2" };
            techDropdown.AddOptions(itemsT);
        }
        //Punto a punto service
        if (frequencyBandSelected == "3G - 80G")
        {
            List<string> itemsT = new List<string>() { "Selecciona una opción", "-" };
            techDropdown.AddOptions(itemsT);
        }
        // Enable Dropdown
        techDropdown.interactable = true;        
    }
    public void selectTech (int val) 
    {
        techSelected = techDropdown.options[val].text;

        // Clear the next dropdowns
        modulationDropdown.interactable = false;
        modulationDropdown.ClearOptions();
        
        // Enable the next dropdown
        assingListModulation();
    }

    public void assingListModulation()
    {
        // Clear dropdown
        modulationDropdown.ClearOptions();

        //Televisión service
        if (techSelected == "ISDB-TB")
        {
            List<string> itemsMod = new List<string>() { "Selecciona una opción", "QPSK", "16-QAM", "64-QAM", "DQPSK" };
            modulationDropdown.AddOptions(itemsMod);
        }
        if (techSelected == "DVB-T2")
        {
            List<string> itemsMod = new List<string>() { "Selecciona una opción", "QPSK", "16-QAM", "64-QAM", "256-QAM" };
            modulationDropdown.AddOptions(itemsMod);
        }
        //Punto a punto service
        if (techSelected == "-")
        {
            List<string> itemsMod = new List<string>() { "Selecciona una opción", "16-QAM", "32-QAM", "64-QAM", "256-QAM", "512-QAM", "1024-QAM", "APSK", "4FSK", "4QAP" };
            modulationDropdown.AddOptions(itemsMod);
        }
        // Enable Dropdown
        modulationDropdown.interactable = true;       
    }
    public void selectModulation (int val) 
    {
        modulationSelected = modulationDropdown.options[val].text;

        // Clear the next dropdowns
        propagationModelDropdown.interactable = false;
        propagationModelDropdown.ClearOptions();
        
        // Enable the next dropdown
        assingListPropagationModel();
    }

    public void assingListPropagationModel()
    {
        // Clear dropdown
        propagationModelDropdown.ClearOptions();

        if (serviceSelected == "Televisión")
        {
            List<string> itemsPM = new List<string>() { "Selecciona una opción", "WALFISH IKEGAMI", "OKUMURA HATA", "XIA BERTONI" };
            propagationModelDropdown.AddOptions(itemsPM);
        }
        if (serviceSelected == "Punto a punto")
        {
            List<string> itemsPM = new List<string>() { "Selecciona una opción", "-" };
            propagationModelDropdown.AddOptions(itemsPM);
        }
        // Enable Dropdown
        propagationModelDropdown.interactable = true;  
    }
    public void selectPropagationModel (int val) 
    {
        propagationModelSelected = propagationModelDropdown.options[val].text;

        // Validate that dropdown selected an option
        if(propagationModelSelected != "Seleccione una opción")
        {
            btnAccept.interactable = true;
        }
    }

    public void saveTowerData ()
    {
        player.updateTowerService(serviceSelected);
        player.updateTowerFreqBand(frequencyBandSelected);
        player.updateTowerTechnology(techSelected);
        player.updateTowerModulation(modulationSelected);
        player.updateTowerPropagationModel(propagationModelSelected);
    }
}
