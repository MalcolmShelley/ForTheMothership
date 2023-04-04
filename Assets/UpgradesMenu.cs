using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesMenu : MonoBehaviour
{
    //TODO: make this work for other scenes
    public void NextLevel() { 
        SceneManager.LoadScene(GlobalManager.getLevel());
        GlobalManager.incrementLevel();
    }

    public void upgradeShield() {
        //TODO: if currency == not enough throw error else run a function in player that adds the shield

    }

    public void upgradeLaser() {
        laser.UpgradeLaser();

    }

    public void upgradeEnergyRegen() {
        //TODO: if currency == not enough throw error else run a function in player that adds the shield

    }

    public void upgradeSpeed() {
        ShipMovement.UpgradeSpeed();

    }

    public void upgradeTraktorSpeed() {
        Animal.UpgradeTraktorSpeed();

    }

    public void upgradeTraktorCapacity() {
        // FireTraktor.UpgradeTraktorCapacity();

    }

    public void repair() {

    }
}
