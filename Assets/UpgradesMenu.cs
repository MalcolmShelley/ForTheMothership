using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesMenu : MonoBehaviour
{
    //TODO: make this work for other scenes
    public void NextLevel() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void getShield() {
        //TODO: if currency == not enough throw error
    }
}
