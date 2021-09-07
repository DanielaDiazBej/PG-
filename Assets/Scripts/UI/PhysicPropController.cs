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
    public Slider directionSlider;
    public Slider azimutSlider;

    public TMP_InputField IFHeight;
    public TMP_InputField IFInclination;
    public TMP_InputField IFDirection;
    public TMP_InputField IFAzimut;

    public string heightSelected;
    public string inclinationSelected;
    public string directionSelected;
    public string azimutSelected;

    // Start is called before the first frame update
    void Start()
    {
        // Listen inputs to update sliders
        IFHeight.onEndEdit.AddListener(OnInputFieldChangedHeight);
        IFInclination.onEndEdit.AddListener(OnInputFieldChangedInclination);
        IFDirection.onEndEdit.AddListener(OnInputFieldChangedDirection);
        IFAzimut.onEndEdit.AddListener(OnInputFieldChangedAzimut);
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
    private void OnInputFieldChangedDirection(string newText)
    {
        if (float.TryParse(newText, out var value))
        {
            value = Mathf.Clamp(value, directionSlider.minValue, directionSlider.maxValue);

            // Update input
            IFDirection.text = value.ToString("F");
            // Update slider
            directionSlider.value = value;
            // Update selection
            directionSelected = value.ToString("F");
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            directionSlider.value = Mathf.Clamp(0, directionSlider.minValue, directionSlider.maxValue);
            IFDirection.text = directionSlider.value.ToString("F");
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
    public void selectDirection (float value)
    {
        // Update input
        IFDirection.text = value.ToString("F");
        // Update selection
        directionSelected = value.ToString("F");
    }
    public void selectAzimut (float value)
    {
        // Update input
        IFAzimut.text = value.ToString("F");
        // Update selection
        azimutSelected = value.ToString("F");
    }

    public void saveAntennaData ()
    {
        player.updateAntennaHeight(heightSelected);
        player.updateAntennaInclination(inclinationSelected);
        player.updateAntennaDirection(directionSelected);
        player.updateAntennaAzimut(azimutSelected);
    }
}
