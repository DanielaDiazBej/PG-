using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntennaPropController : MonoBehaviour
{
    public PlayerController player;

    public Dropdown modulationDirDropdown;
    public Dropdown gainDropdown;

    public Button btnAccept;

    public int modulationDirVal, gainVal;

    public string serviceSelected;
    public string typeSelected;
    public string modulationDirSelected;
    public string gainSelected;

    // Start is called before the first frame update
    void Start()
    {
        btnAccept.interactable = false;
    }

    public void clearData () {
        modulationDirDropdown.ClearOptions();
        gainDropdown.ClearOptions();
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
    }
    public void selectModulationDir (int val) 
    {
        modulationDirSelected = modulationDirDropdown.options[val].text;    

        // Validate that dropdown selected an option
        if(gainSelected != "Seleccione una opción" && modulationDirSelected != "Seleccione una opción")
        {
            btnAccept.interactable = true;
        }
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
    }
    public void selectGain (int val) 
    {
        gainSelected = gainDropdown.options[val].text;

        // Validate that dropdown selected an option
        if(gainSelected != "Seleccione una opción" && modulationDirSelected != "Seleccione una opción")
        {
            btnAccept.interactable = true;
        }
    }

    public void saveAntennaData ()
    {
        player.updateAntennaModulationDir(modulationDirSelected);
        player.updateAntennaModulationGain(gainSelected);
    }
}
