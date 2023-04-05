using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{

    private int maxEnergy = 100;
    private float energyRegen;
    private float currentEnergy = 100;

    Slider energySlider;

    // Start is called before the first frame update
    void Start()
    {
        energySlider = GetComponent<Slider>();
        energyRegen = GlobalManager.getEnergyRegen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void regenEnergy()
    {
        if(currentEnergy < maxEnergy)
        {
            currentEnergy += energyRegen * 40 * Time.deltaTime;
            energySlider.value = currentEnergy;
        }
    }

    public float useEnergy(float ammount)
    {
        if (currentEnergy > 5)
        {
            currentEnergy -= ammount;
            energySlider.value = currentEnergy;
        }
        return currentEnergy;
    }

    public float getEnergy()
    {
        return currentEnergy;
    }
}
