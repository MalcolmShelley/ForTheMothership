using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() {
        GlobalManager.resetVariables();
        SceneManager.LoadScene(GlobalManager.getLevel()); //Load first level
        GlobalManager.incrementLevel();
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
