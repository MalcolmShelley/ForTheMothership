using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;

    public int comradeCount;
    public int rations;
    public int playerHealth;

    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        comradeCount = 1000;
        rations = 0;
        playerHealth = 100;
    }

    public void addRations(int newRationCount)
    {
        this.rations += newRationCount;
    }
    public void useRations(int usedRationCount)
    {
        this.rations -= usedRationCount;
    }
    public int getRations()
    {
        return this.rations;
    }
}
