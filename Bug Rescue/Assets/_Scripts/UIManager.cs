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

    private int _count = 0;


    public void Collectable() {
        _count++;
		ScoreText.text = _count.ToString ();
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
