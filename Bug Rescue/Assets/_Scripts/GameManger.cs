using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour, IGameController {
    
    
    public void StartNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void RestartLevel() {
        UIManager.CountScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenMainMenu() {
        UIManager.CountScore = 0;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    
}
