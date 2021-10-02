using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntennaPropController : MonoBehaviour
{
    public PlayerController player;

    public Dropdown radiationDirDropdown;
    public Dropdown gainDropdown;

    public Button btnAccept;

    public int modulationDirVal, gainVal;

    public string serviceSelected;
    public string typeSelected;
    public string radiationDirSelected = "Seleccione una opción";
    public string gainSelected = "Seleccione una opción";

    // Start is called before the first frame update
    void Start()
    {
        btnAccept.interactable = false;
    }

    public void clearData () {
        radiationDirDropdown.ClearOptions();
        gainDropdown.ClearOptions();
    }

    public void assingListRadiationDir()
    {
        // Clear dropdown
        radiationDirDropdown.ClearOptions();

        if (serviceSelected == "Televisión")
        {
            if (typeSelected == "Directiva")
            {
                List<string> itemsMD = new List<string>() { "Selecciona una opción", "45", "60", "90" };
                radiationDirDropdown.AddOptions(itemsMD);
            }
            else if (typeSelected == "Omnidireccional")
            {
                List<string> itemsMD = new List<string>() { "Selecciona una opción", "360" };
                radiationDirDropdown.AddOptions(itemsMD);
            }
        }
        if (serviceSelected == "Punto a punto")
        {
            List<string> itemsMD = new List<string>() { "Selecciona una opción", "0", "1", "2", "3", "5", "10" };
            radiationDirDropdown.AddOptions(itemsMD);
        }  
    }
    public void selectRadiationDir (int val) 
    {
        radiationDirSelected = radiationDirDropdown.options[val].text;    

        // Validate that dropdown selected an option
        if(gainSelected != "Seleccione una opción" && radiationDirSelected != "Seleccione una opción")
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
        if(gainSelected != "Seleccione una opción" && radiationDirSelected != "Seleccione una opción")
        {
            btnAccept.interactable = true;
        }
    }

    public void fillData (Antenna value)
    {
        if(value.radiationDirection != "---" && value.gain != "---"){
            radiationDirDropdown.value =  radiationDirDropdown.options.FindIndex(option => option.text == value.radiationDirection);
            gainDropdown.value = gainDropdown.options.FindIndex(option => option.text == value.gain);
        }
    }
    
    public void saveAntennaData ()
    {
        player.updateAntennaRadiationDir(radiationDirSelected);
        player.updateAntennaGain(gainSelected);
    }
}
