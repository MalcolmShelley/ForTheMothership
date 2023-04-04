using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalManager
{

    private static int comradeCount = 1000;
    private static int rations = 0;
    private static int playerHealth = 100;
    private static int levelCount = 4;

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

    public static int getPlayerHealth() {
        return playerHealth;
    }

    public static int reducePlayerHealth(int ammount)
    {
        playerHealth -= ammount;
        return playerHealth;
    }

    public static int getLevel() {
        return levelCount;
    }

    public static void incrementLevel() {
        levelCount++;
    }

    public static void resetVariables() {
        comradeCount = 1000; //MAKE SURE THESE MATCH THE VARIABLES WHEN THEY START
        rations = 0;
        playerHealth = 100;
        levelCount = 4;
    }
}
