using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sliders : MonoBehaviour
{
    public Slider SlHeight;
    public Slider SlInclination;
    public Slider SlDirection;
    public Slider SlAzimut;
    public TMP_InputField IFHeight;
    public TMP_InputField IFInclination;
    public TMP_InputField IFDirection;
    public TMP_InputField IFAzimut;

 
   private void Awake()
    {
        IFHeight.onEndEdit.AddListener(OnInputFieldChanged);
        SlHeight.onValueChanged .AddListener( OnSliderChangedHeiht);

        IFInclination.onEndEdit.AddListener(OnInputFieldChanged);
        SlInclination.onValueChanged .AddListener( OnSliderChangedInclination);

        IFDirection.onEndEdit.AddListener(OnInputFieldChanged);
        SlDirection.onValueChanged .AddListener( OnSliderChangedDirection);

        IFAzimut.onEndEdit.AddListener(OnInputFieldChanged);
        SlAzimut.onValueChanged .AddListener( OnSliderChangedAzimut);

        OnSliderChangedHeiht(SlHeight.value);
        OnSliderChangedInclination(SlInclination.value);
        OnSliderChangedDirection(SlDirection.value);
        OnSliderChangedAzimut(SlAzimut.value);
        
    }

    private void OnInputFieldChanged(string newText)
    {
        if (float.TryParse(newText, out var value1))
        {
            value1 = Mathf.Clamp(value1, SlHeight.minValue, SlHeight.maxValue);
            
            IFHeight.text = value1.ToString("F");
            SlHeight.value = value1;
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            SlHeight.value = Mathf.Clamp(0, SlHeight.minValue, SlHeight.maxValue);
            IFHeight.text = SlHeight.value.ToString("F");
        }
        if (float.TryParse(newText, out var value2))
        {
            value2 = Mathf.Clamp(value2, SlInclination.minValue, SlInclination.maxValue);
            
            IFInclination.text = value2.ToString("F");
            SlInclination.value = value2;
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            SlInclination.value = Mathf.Clamp(0, SlInclination.minValue, SlInclination.maxValue);
            IFInclination.text = SlInclination.value.ToString("F");
        }
        if (float.TryParse(newText, out var value3))
        {
            value3 = Mathf.Clamp(value3, SlDirection.minValue, SlDirection.maxValue);

            IFDirection.text = value3.ToString("F");
            SlDirection.value = value3;
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            SlDirection.value = Mathf.Clamp(0, SlDirection.minValue, SlDirection.maxValue);
            IFDirection.text = SlDirection.value.ToString("F");
        }
        if (float.TryParse(newText, out var value4))
        {
            value4 = Mathf.Clamp(value4, SlAzimut.minValue, SlAzimut.maxValue);
            
            IFAzimut.text = value4.ToString("F");
            SlAzimut.value = value4;
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            SlAzimut.value = Mathf.Clamp(0, SlAzimut.minValue, SlAzimut.maxValue);
            IFAzimut.text = SlAzimut.value.ToString("F");
        }
    }

    private void OnSliderChangedHeiht(float newValue1)
    {
        IFHeight.text = newValue1.ToString("F");
     
    }
    private void OnSliderChangedInclination(float newValue2)
    {
        IFInclination.text = newValue2.ToString("F");
    }
    private void OnSliderChangedDirection(float newValue3)
    {
        IFDirection.text = newValue3.ToString("F");
    }
    private void OnSliderChangedAzimut(float newValue4)
    {
        IFAzimut.text = newValue4.ToString("F");
    }
}