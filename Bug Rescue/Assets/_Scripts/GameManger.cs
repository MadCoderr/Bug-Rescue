using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour, IGameController {


    void Awake() {
       // DontDestroyOnLoad(this.gameObject);
    }
    
    public void StartNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    
}
