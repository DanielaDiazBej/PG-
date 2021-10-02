using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoController : MonoBehaviour
{

    public TextMeshProUGUI txServiceValue;
    public TextMeshProUGUI txFrequencyValue;
    public TextMeshProUGUI txTechValue;
    public TextMeshProUGUI txModulationValue;
    public TextMeshProUGUI txModelValue;
    public TextMeshProUGUI txTypeValue;
    public TextMeshProUGUI txRadiationDirValue;
    public TextMeshProUGUI txGainValue;
    public TextMeshProUGUI txHeightValue;
    public TextMeshProUGUI txInclinationValue;
    public TextMeshProUGUI txAzimutValue;
    public TextMeshProUGUI txDistanceValue;
    
    public void setService(string value){
        txServiceValue.text = value;
    }
    public void setFrequency(string value){
        txFrequencyValue.text = value;
    }
    public void setTech(string value){
        txTechValue.text = value;
    }
    public void setModulation(string value){
        txModulationValue.text = value;
    }
    public void setModel(string value){
        txModelValue.text = value;
    }
    public void setType(string value){
        txTypeValue.text = value;
    }
    public void setRadiationDir(string value){
        txRadiationDirValue.text = value;
    }
    public void setGain(string value){
        txGainValue.text = value;
    }
    public void setHeight(string value){
        txHeightValue.text = value;
    }
    public void setInclination(string value){
        txInclinationValue.text = value;
    }
    public void setAzimut(string value){
        txAzimutValue.text = value;
    }
    public void setDistance(string value){
        txDistanceValue.text = value;
    }

    public void updateTowerData(Service value)
    {
        txServiceValue.text = value.type;
        txFrequencyValue.text = value.frequencyBand;
        txTechValue.text = value.technology;
        txModulationValue.text = value.modulation;
        txModelValue.text = value.propagationModel;
    }

    public void updateAntennaData(Antenna value)
    {
        txTypeValue.text = value.type;
        txRadiationDirValue.text = value.radiationDirection;
        txGainValue.text = value.gain;

        txHeightValue.text = value.height;
        txInclinationValue.text = value.inclination;
        txAzimutValue.text = value.azimut;
    }

    public void clearData()
    {
        txServiceValue.text = "---";
        txFrequencyValue.text = "---";
        txTechValue.text = "---";
        txModulationValue.text = "---";
        txModelValue.text = "---";

        txTypeValue.text = "---";
        txRadiationDirValue.text = "---";
        txGainValue.text = "---";

        txHeightValue.text = "---";
        txInclinationValue.text = "---";
        txAzimutValue.text = "---";
    }
}
