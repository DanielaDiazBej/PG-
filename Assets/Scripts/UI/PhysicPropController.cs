using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhysicPropController : MonoBehaviour
{
    public PlayerController player;

    public Slider heightSlider;
    public Slider inclinationSlider;
    public Slider azimutSlider;

    public TMP_InputField IFHeight;
    public TMP_InputField IFInclination;
    public TMP_InputField IFAzimut;

    public string heightSelected;
    public string inclinationSelected;
    public string azimutSelected;

    // Start is called before the first frame update
    void Start()
    {
        // Listen inputs to update sliders
        IFHeight.onEndEdit.AddListener(OnInputFieldChangedHeight);
        IFInclination.onEndEdit.AddListener(OnInputFieldChangedInclination);
        IFAzimut.onEndEdit.AddListener(OnInputFieldChangedAzimut);
    }

    public void changeStateAzimut(bool value){
        azimutSlider.interactable = value;
        IFAzimut.interactable = value;
    }
    public void changeStateInclination(bool value){
        inclinationSlider.interactable = value;
        IFInclination.interactable = value;
    }

    private void OnInputFieldChangedHeight(string newText)
    {
        if (float.TryParse(newText, out var value))
        {
            value = Mathf.Clamp(value, heightSlider.minValue, heightSlider.maxValue);
            
            // Update input
            IFHeight.text = value.ToString("F");
            // Update slider
            heightSlider.value = value;
            // Update selection
            heightSelected = value.ToString("F");
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            heightSlider.value = Mathf.Clamp(0, heightSlider.minValue, heightSlider.maxValue);
            IFHeight.text = heightSlider.value.ToString("F");
        }
    }
    private void OnInputFieldChangedInclination(string newText)
    {
        if (float.TryParse(newText, out var value))
        {
            value = Mathf.Clamp(value, inclinationSlider.minValue, inclinationSlider.maxValue);
            
            // Update input
            IFInclination.text = value.ToString("F");
            // Update slider
            inclinationSlider.value = value;
            // Update selection
            inclinationSelected = value.ToString("F");
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            inclinationSlider.value = Mathf.Clamp(0, inclinationSlider.minValue, inclinationSlider.maxValue);
            IFInclination.text = inclinationSlider.value.ToString("F");
        }
    }
    private void OnInputFieldChangedAzimut(string newText)
    {
        if (float.TryParse(newText, out var value))
        {
            value = Mathf.Clamp(value, azimutSlider.minValue, azimutSlider.maxValue);
            
            // Update input
            IFAzimut.text = value.ToString("F");
            // Update slider
            azimutSlider.value = value;
            // Update selection
            azimutSelected = value.ToString("F");
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            azimutSlider.value = Mathf.Clamp(0, azimutSlider.minValue, azimutSlider.maxValue);
            IFAzimut.text = azimutSlider.value.ToString("F");
        }
    }

    public void selectHeight (float value)
    {
        // Update input
         IFHeight.text = value.ToString("F");
         // Update selection
         heightSelected = value.ToString("F");
    }
    public void selectInclination (float value)
    {
        // Update input
        IFInclination.text = value.ToString("F");
        // Update selection
        inclinationSelected = value.ToString("F");
    }
    public void selectAzimut (float value)
    {
        // Update input
        IFAzimut.text = value.ToString("F");
        // Update selection
        azimutSelected = value.ToString("F");
    }

    public void fillData (Antenna value)
    {
        if(value.height != "---" && value.height != "" && value.inclination != "---" && value.inclination != "" && value.azimut != "---" && value.azimut != ""){
            heightSlider.value =  float.Parse(value.height);
            inclinationSlider.value = float.Parse(value.inclination);
            azimutSlider.value = float.Parse(value.azimut);
        }
        else
        {
            heightSlider.value =  80f;
            inclinationSlider.value = 0f;
            azimutSlider.value = 0f;
        }
    }

    public void saveAntennaData ()
    {
        player.updateAntennaHeight(heightSelected);
        player.updateAntennaInclination(inclinationSelected);
        player.updateAntennaAzimut(azimutSelected);

        player.rotateAntenna(float.Parse(inclinationSelected), float.Parse(azimutSelected));
    }
}
