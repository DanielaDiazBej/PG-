using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveController : MonoBehaviour
{
    public PlayerController player;

    // UI
    public GameObject panelPower;

    public Slider powerSlider;

    public TMP_InputField IFPower;

     private string powerSelected;

     // Data
     private float distance = 0f;

    // Antenna
    private ParticleSystem particle;

    void Start()
    {
        // Listen inputs to update sliders
        IFPower.onEndEdit.AddListener(OnInputFieldChangedPower);
    }

    private void OnInputFieldChangedPower(string newText)
    {
        if (float.TryParse(newText, out var value))
        {
            value = Mathf.Clamp(value, powerSlider.minValue, powerSlider.maxValue);
            
            // Update input
            IFPower.text = value.ToString("F");
            // Update slider
            powerSlider.value = value;
            // Update selection
            powerSelected = value.ToString("F");
        }
        else
        {
            Debug.LogWarning("Input Format Error!", this);
            powerSlider.value = Mathf.Clamp(0, powerSlider.minValue, powerSlider.maxValue);
            IFPower.text = powerSlider.value.ToString("F");
        }
    }

    public void selectPower (float value)
    {
        // Update input
         IFPower.text = value.ToString("F");
         // Update selection
         powerSelected = value.ToString("F");

        float power = Remap(value, 1f, 2f, 0f, 6f);

        // Add power to distance
        float tempDistance = distance + value - 1;        

        // Set distance in particles
        var main = particle.main;
        main.startLifetime = Remap(tempDistance, 0f, 5f, 0f, 30f);

        // Update info panel
        player.updateAntennaDistance( Mathf.Round(tempDistance).ToString() + " Km");
    }

    public void calculateWave(Antenna antenna, Service service) {

        particle = antenna.coverParticle;

        // Lost
        float L = 0f;

        float f = 0;

        if(service.frequencyBand == "470 - 614M"){
            f = Random.Range(470f, 614f);
            L = 95f;
        }else if(service.frequencyBand == "3G - 80G"){
            f = Random.Range(3f, 80f);
            L = 125f;
        }        

        f = 20 * (Mathf.Log10(f));

        // Distance
        distance = ((L - 32.5f - f) / 20);        
        distance = Mathf.Pow(10, distance);

        // Set distance in particles
        var main = particle.main;
        main.startLifetime = Remap(distance, 0f, 5f, 0f, 30f);

        // Set angle in particles
        var shape = particle.shape;
        shape.angle = float.Parse(antenna.radiationDirection);

        // Update info panel
        player.updateAntennaDistance( Mathf.Round(distance).ToString() + " Km");

        // Show panel
        panelPower.SetActive(true);
    }

    public float Remap (float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
