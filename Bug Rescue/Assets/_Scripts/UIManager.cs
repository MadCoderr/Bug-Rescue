using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIController {
    
    [SerializeField]
	private Text ScoreText;

    [SerializeField]
    private Canvas PauseMenu;

    [SerializeField]
    private Button ResumeBtn;

    public static int CountScore = 0;

    private void Start() {
        ScoreText.text = CountScore.ToString();
    }

    public void Collectable() {
        CountScore++;
		ScoreText.text = CountScore.ToString ();
    }

    public void ShowPauseMenu() {
        PauseMenu.gameObject.SetActive(true);
    }

    public void HidePauseMenu() {
        PauseMenu.gameObject.SetActive(false);
    }

    public void GameOver() {
        ResumeBtn.interactable = false;
        ShowPauseMenu();
    }
}
