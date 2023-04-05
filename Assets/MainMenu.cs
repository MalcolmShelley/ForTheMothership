using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public GameObject TMPScore;
    TextMeshProUGUI scoreText;

    void Start() {
        scoreText = TMPScore.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Comrades: \n" + GlobalManager.getComrades() + "\n\n Final Score:\n" 
        + (GlobalManager.getScore() + GlobalManager.getComrades() * 10);
    }

    public void PlayGame() {
        GlobalManager.resetVariables();
        GlobalManager.incrementLevel();
        SceneManager.LoadScene(GlobalManager.getLevel()); //Load first level
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("This works in the real game not the editor according to some random guy on Youtube");
    }

    public void NewGamePlus() {
        GlobalManager.resetLevel();
        SceneManager.LoadScene(2); //Go to upgrade screen first
    }

}
