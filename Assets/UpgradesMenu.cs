using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradesMenu : MonoBehaviour
{
    private int shieldPrice = 100;
    private int laserPrice = 100;
    private int energyRegenPrice = 100;
    private int speedPrice = 100;
    private int traktorSpeedPrice = 100;
    private int traktorCapacityPrice = 100;
    private int repairPrice = 0;
    
    //To make the text changeable with script
    public GameObject TMPUpgrade;
    TextMeshProUGUI upgradeText;
    
    public string text;

    //To make text type over time
    private float delay = 0.03f;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {

        text = "Greetings comrade! \nWhat is it that you need?";
        upgradeText = TMPUpgrade.GetComponent<TextMeshProUGUI>();

        StartCoroutine(ShowText());
        repairPrice = 100 - GlobalManager.getPlayerHealth();
    }

    IEnumerator ShowText() {
        for (int i = 0; i <= text.Length; i++) {
            currentText = text.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    void Update() {
        upgradeText.text = currentText;
    }

    //TODO: make this work for other scenes
    public void NextLevel() { 
        SceneManager.LoadScene(GlobalManager.getLevel());
        GlobalManager.incrementLevel();
    }

    public void upgradeShield() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() > shieldPrice) {
            if (GlobalManager.getRations() > shieldPrice) {
                GlobalManager.useRations(shieldPrice);
            } else {
                GlobalManager.useComrades(shieldPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            //TODO: Make this do something once shield is implemented
            GlobalManager.upgradeShield();
            
            startText("This one will keep you safe, comrade.");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeLaser() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() > laserPrice) {
            if (GlobalManager.getRations() > laserPrice) {
                GlobalManager.useRations(laserPrice);
            } else {
                GlobalManager.useComrades(laserPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }
            GlobalManager.upgradeLaserDamage();

            startText("They'll be gone in an instant, comrade!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeEnergyRegen() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() > energyRegenPrice) {
            if (GlobalManager.getRations() > energyRegenPrice) {
                GlobalManager.useRations(energyRegenPrice);
            } else {
                GlobalManager.useComrades(energyRegenPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            //TODO: Make this do something once energy is implemented
            GlobalManager.upgradeEnergyRegen();

            startText("New charge packs can keep you in the fight longer!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeSpeed() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() > speedPrice) {
            if (GlobalManager.getRations() > speedPrice) {
                GlobalManager.useRations(speedPrice);
            } else {
                GlobalManager.useComrades(speedPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            GlobalManager.upgradeShipSpeed();

            startText("Let's see them catch you now!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeTraktorSpeed() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() > traktorSpeedPrice) {
            if (GlobalManager.getRations() > traktorSpeedPrice) {
                GlobalManager.useRations(traktorSpeedPrice);
            } else {
                GlobalManager.useComrades(traktorSpeedPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            GlobalManager.upgradeTraktorSpeed();

            startText("We'll scoop them up in an instant!");
        } else {
            startText("Sorry comrade, you are out of funds.");
        }

    }

    public void upgradeTraktorCapacity() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() > traktorCapacityPrice) {
            if (GlobalManager.getRations() > traktorCapacityPrice) {
                GlobalManager.useRations(traktorCapacityPrice);
            } else {
                GlobalManager.useComrades(traktorCapacityPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            //TODO: Make this do something once TraktorCapacity is implemented
            GlobalManager.upgradeTraktorCapacity();

            startText("Bring us back more food with this one!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }

    }

    public void repair() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() > repairPrice) {
            if (GlobalManager.getRations() > repairPrice) {
                GlobalManager.useRations(repairPrice);
            } else {
                GlobalManager.useComrades(repairPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            GlobalManager.resetPlayerHealth();

            startText("There you go! good as new!");
        } else {
            startText("Sorry comrade, you are out of funds.");
        }
    }

    public void startText(string newText) {
        StopCoroutine(ShowText());
        this.text = newText;
        currentText = "";
        StartCoroutine(ShowText());
    }
}
