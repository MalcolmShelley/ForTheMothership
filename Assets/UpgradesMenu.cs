using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradesMenu : MonoBehaviour
{
    private int shieldPrice = 10;
    private int laserPrice = 20;
    private int energyRegenPrice = 10;
    private int speedPrice = 15;
    private int traktorSpeedPrice = 8;
    private int traktorCapacityPrice = 10;
    private int repairPrice = 0;
    
    //To show price
    public GameObject TMPLaser;
    TextMeshProUGUI laserText;
    public GameObject TMPShield;
    TextMeshProUGUI shieldText;
    public GameObject TMPSpeed;
    TextMeshProUGUI speedText;
    public GameObject TMPTraktorSpeed;
    TextMeshProUGUI traktorSpeedText;
    public GameObject TMPEnergyRegen;
    TextMeshProUGUI energyRegenText;
    public GameObject TMPTraktorCapacity;
    TextMeshProUGUI traktorCapacityText;
    public GameObject TMPRepair;
    TextMeshProUGUI repairText;

    // currencies
    public GameObject TMPRations;
    TextMeshProUGUI rationsText;
    public GameObject TMPComrades;
    TextMeshProUGUI comradesText;

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

        // Set the TMP to the respective gameObject selected in Unity
        upgradeText = TMPUpgrade.GetComponent<TextMeshProUGUI>();

        laserText = TMPLaser.GetComponent<TextMeshProUGUI>();
        shieldText = TMPShield.GetComponent<TextMeshProUGUI>();
        speedText = TMPSpeed.GetComponent<TextMeshProUGUI>();
        traktorSpeedText = TMPTraktorSpeed.GetComponent<TextMeshProUGUI>();
        energyRegenText = TMPEnergyRegen.GetComponent<TextMeshProUGUI>();
        traktorCapacityText = TMPTraktorCapacity.GetComponent<TextMeshProUGUI>();
        repairText = TMPRepair.GetComponent<TextMeshProUGUI>();

        comradesText = TMPComrades.GetComponent<TextMeshProUGUI>();
        rationsText = TMPRations.GetComponent<TextMeshProUGUI>();
        
        StartCoroutine(ShowText());
        repairPrice = (100 - GlobalManager.getPlayerHealth())/10;

        laserText.text = laserPrice.ToString() + " x";
        shieldText.text = shieldPrice.ToString() + " x";
        speedText.text = speedPrice.ToString() + " x";
        traktorSpeedText.text = traktorSpeedPrice.ToString() + " x";
        energyRegenText.text = energyRegenPrice.ToString() + " x";
        traktorCapacityText.text = traktorCapacityPrice.ToString() + " x";
        repairText.text = repairPrice.ToString() + " x";
    }

    IEnumerator ShowText() {
        for (int i = 0; i <= text.Length; i++) {
            currentText = text.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    void Update() {
        upgradeText.text = currentText;
        comradesText.text = GlobalManager.getComrades().ToString();
        rationsText.text = GlobalManager.getRations().ToString();

    }

    //TODO: make this work for other scenes
    public void NextLevel() { 
        SceneManager.LoadScene(GlobalManager.getLevel());
        GlobalManager.incrementLevel();
    }

    public void upgradeShield() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() >= shieldPrice) {
            if (GlobalManager.getRations() >= shieldPrice) {
                GlobalManager.useRations(shieldPrice);
            } else {
                GlobalManager.useComrades(shieldPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            //TODO: Make this do something once shield is implemented
            GlobalManager.upgradeShield();
            
            shieldText.text = "SOLD OUT";
            startText("This one will keep you safe, comrade.");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeLaser() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() >= laserPrice) {
            if (GlobalManager.getRations() >= laserPrice) {
                GlobalManager.useRations(laserPrice);
            } else {
                GlobalManager.useComrades(laserPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }
            GlobalManager.upgradeLaserDamage();

            laserText.text = "SOLD OUT";
            startText("They'll be gone in an instant, comrade!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeEnergyRegen() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() >= energyRegenPrice) {
            if (GlobalManager.getRations() >= energyRegenPrice) {
                GlobalManager.useRations(energyRegenPrice);
            } else {
                GlobalManager.useComrades(energyRegenPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            //TODO: Make this do something once energy is implemented
            GlobalManager.upgradeEnergyRegen();
            
            energyRegenText.text = "SOLD OUT";
            startText("New charge packs can keep you in the fight longer!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeSpeed() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() >= speedPrice) {
            if (GlobalManager.getRations() >= speedPrice) {
                GlobalManager.useRations(speedPrice);
            } else {
                GlobalManager.useComrades(speedPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            GlobalManager.upgradeShipSpeed();

            speedText.text = "SOLD OUT";
            startText("Let's see them catch you now!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }
    }

    public void upgradeTraktorSpeed() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() >= traktorSpeedPrice) {
            if (GlobalManager.getRations() >= traktorSpeedPrice) {
                GlobalManager.useRations(traktorSpeedPrice);
            } else {
                GlobalManager.useComrades(traktorSpeedPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            GlobalManager.upgradeTraktorSpeed();

            traktorSpeedText.text = "SOLD OUT";
            startText("We'll scoop them up in an instant!");
        } else {
            startText("Sorry comrade, you are out of funds.");
        }

    }

    public void upgradeTraktorCapacity() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() >= traktorCapacityPrice) {
            if (GlobalManager.getRations() >= traktorCapacityPrice) {
                GlobalManager.useRations(traktorCapacityPrice);
            } else {
                GlobalManager.useComrades(traktorCapacityPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            //TODO: Make this do something once TraktorCapacity is implemented
            GlobalManager.upgradeTraktorCapacity();

            traktorCapacityText.text = "SOLD OUT";
            startText("Bring us back more food with this one!");
        } else {
            startText("Sorry comrade, you are out of funds.");

        }

    }

    public void repair() {
        if (GlobalManager.getRations() + GlobalManager.getComrades() >= repairPrice) {
            if (GlobalManager.getRations() >= repairPrice) {
                GlobalManager.useRations(repairPrice);
            } else {
                GlobalManager.useComrades(repairPrice - GlobalManager.getRations());
                GlobalManager.useRations(GlobalManager.getRations());
            }

            GlobalManager.resetPlayerHealth();

            repairText.text = "SOLD OUT";
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
