using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalManager
{
    private static int score = 0;
    private static int comradeCount = 100;
    private static int rations = 0;
    private static int playerHealth = 100;
    private static int levelCount = 4;
    private static float traktorSpeed = 5f;
    private static int traktorCapacity = 1;
    private static float shipSpeed = 5f;
    private static int laserDamage = 1;
    private static int shieldLevel = 0;
    private static float energyRegen = 1f;

    public static void addScore(int scoreIncrease)
    {
        score += scoreIncrease;
    }

    public static int getScore()
    {
        return score;
    }

    public static int getComrades()
    {
        return comradeCount;
    }

    public static void useComrades(int usedComradeCount)
    {
        comradeCount -= usedComradeCount;
    }

    public static void addRations(int newRationCount)
    {
        rations += newRationCount;
    }
    public static void useRations(int usedRationCount)
    {
        rations -= usedRationCount;
    }
    public static int getRations()
    {
        return rations;
    }

    public static void resetPlayerHealth()
    {
        playerHealth = 100; //THIS SHOULD MATCH THE STARTING VALUE
    }
    public static void setPlayerHealth(int newHealth)
    {
        playerHealth = newHealth;
    }
    public static int getPlayerHealth()
    {
        return playerHealth;
    }

    public static int getLevel()
    {
        return levelCount;
    }

    public static void incrementLevel()
    {
        levelCount++;
    }

    public static void resetLevel()
    {
        //Used in NewGame+
        levelCount = 4; //ALSO MAKE SURE THIS MATCHES START
    }

    public static void resetVariables()
    {
        //MAKE SURE THESE MATCH THE VARIABLES WHEN THEY START
        score = 0;
        comradeCount = 100;
        rations = 0;
        playerHealth = 100;
        levelCount = 4;
        traktorSpeed = 5f;
        traktorCapacity = 1;
        shipSpeed = 5f;
        laserDamage = 1;
        shieldLevel = 0;
        energyRegen = 1;
    }

    // Upgrades
    public static float getTraktorSpeed()
    {
        return traktorSpeed;
    }

    public static void upgradeTraktorSpeed()
    {
        traktorSpeed *= 1.5f;
    }

    public static float getShipSpeed()
    {
        return shipSpeed;
    }

    public static void upgradeShipSpeed()
    {
        shipSpeed *= 1.5f;
    }

    public static int getLaserDamage()
    {
        return laserDamage;
    }

    public static void upgradeLaserDamage()
    {
        laserDamage += 1;
    }

    public static int getShieldLevel()
    {
        return shieldLevel;
    }

    public static void upgradeShield()
    {
        shieldLevel += 1;
    }

    public static float getEnergyRegen()
    {
        return energyRegen;
    }

    public static void upgradeEnergyRegen()
    {
        energyRegen *= 1.5f;
    }

    public static int getTraktorCapacity()
    {
        return traktorCapacity;
    }

    public static void upgradeTraktorCapacity()
    {
        traktorCapacity *= 2;
        // traktorCapacity = 9999;
    }
}