using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServicePropController : MonoBehaviour
{
    public PlayerController player;

    public GameObject panelPhysicProps;

    public Dropdown frequencyBandDropdown;
    public Dropdown techDropdown;
    public Dropdown modulationDropdown;
    public Dropdown modulationDirDropdown;
    public Dropdown propagationModelDropdown;
    public Dropdown gainDropdown;

    public Button btnAccept;

    public int frequencyBandVal, modulationVal, modulationDirVal, techVal, propagationModelVal, gainVal;

    public string serviceSelected;
    public string typeSelected;
    public string frequencyBandSelected;
    public string modulationSelected;
    public string modulationDirSelected;
    public string techSelected;
    public string propagationModelSelected;
    public string gainSelected;
    // Start is called before the first frame update
    void Start()
    {
        frequencyBandDropdown.interactable = false;
        techDropdown.interactable = false;
        modulationDropdown.interactable = false;
        modulationDirDropdown.interactable = false;
        propagationModelDropdown.interactable = false;
        gainDropdown.interactable = false;

        btnAccept.interactable = false;
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
        modulationDirDropdown.interactable = false;
        modulationDirDropdown.ClearOptions();
        propagationModelDropdown.interactable = false;
        propagationModelDropdown.ClearOptions();
        gainDropdown.interactable = false;
        gainDropdown.ClearOptions();
        
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
            List<string> itemsT = new List<string>() { "-" };
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
        modulationDirDropdown.interactable = false;
        modulationDirDropdown.ClearOptions();
        propagationModelDropdown.interactable = false;
        propagationModelDropdown.ClearOptions();
        gainDropdown.interactable = false;
        gainDropdown.ClearOptions();
        
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
        modulationDirDropdown.interactable = false;
        modulationDirDropdown.ClearOptions();
        propagationModelDropdown.interactable = false;
        propagationModelDropdown.ClearOptions();
        gainDropdown.interactable = false;
        gainDropdown.ClearOptions();
        
        // Enable the next dropdown
        assingListModulationDir();
    }

     public void assingListModulationDir()
    {
        // Clear dropdown
        modulationDirDropdown.ClearOptions();

        if (serviceSelected == "Televisión")
        {
            if (typeSelected == "Directiva")
            {
                List<string> itemsMD = new List<string>() { "Selecciona una opción", "45", "60", "90" };
                modulationDirDropdown.AddOptions(itemsMD);
            }
            else if (typeSelected == "Omnidireaccional")
            {
                List<string> itemsMD = new List<string>() { "Selecciona una opción", "360" };
                modulationDirDropdown.AddOptions(itemsMD);
            }
        }
        if (serviceSelected == "Punto a punto")
        {
            List<string> itemsMD = new List<string>() { "Selecciona una opción", "0", "1", "2", "3", "5", "10" };
            modulationDirDropdown.AddOptions(itemsMD);
        }
        // Enable Dropdown
        modulationDirDropdown.interactable = true;    
    }
    public void selectModulationDir (int val) 
    {
        modulationDirSelected = modulationDirDropdown.options[val].text;

        // Clear the next dropdowns
        propagationModelDropdown.interactable = false;
        propagationModelDropdown.ClearOptions();
        gainDropdown.interactable = false;
        gainDropdown.ClearOptions();
        
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
            List<string> itemsPM = new List<string>() { "Selecciona una opción" };
            propagationModelDropdown.AddOptions(itemsPM);
        }
        // Enable Dropdown
        propagationModelDropdown.interactable = true;  
    }
    public void selectPropagationModel (int val) 
    {
        propagationModelSelected = propagationModelDropdown.options[val].text;

        // Clear the next dropdowns
        gainDropdown.interactable = false;
        gainDropdown.ClearOptions();
        
        // Enable the next dropdown
        assingListGain();
    }

    public void assingListGain()
    {
        // Clear dropdown
        gainDropdown.ClearOptions();

        if (serviceSelected == "Televisión")
        {
            List<string> itemsG = new List<string>() { "Selecciona una opción", "3", "6", "9", "12" };
            gainDropdown.AddOptions(itemsG);
        }
        if (serviceSelected == "Punto a punto")
        {
            List<string> itemsG = new List<string>() { "Selecciona una opción", "20", "30", "40", "50" };
            gainDropdown.AddOptions(itemsG);
        }
        // Enable Dropdown
        gainDropdown.interactable = true;  
    }
    public void selectGain (int val) 
    {
        gainSelected = gainDropdown.options[val].text;

        // Validate that dropdown selected an option
        if(gainSelected != "Seleccione una opción")
        {
            btnAccept.interactable = true;
        }
    }

    public void saveAntennaData ()
    {
        player.updateAntennaFreqBand(frequencyBandSelected);
        player.updateAntennaTechnology(techSelected);
        player.updateAntennaModulation(modulationSelected);
        player.updateAntennaModulationDir(modulationDirSelected);
        player.updateAntennaPropagationModel(propagationModelSelected);
        player.updateAntennaModulationGain(gainSelected);
    }
}
