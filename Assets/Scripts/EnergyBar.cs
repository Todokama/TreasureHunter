using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    public void SetEnergy(int energy)
    {
        slider.value = energy;
    }

    public float currentEnergy()
    {
        return slider.value;
    }

    public void SetMaxEnergy(int energy)
    {

        slider.maxValue = energy;
        slider.value = energy;
    }
}
