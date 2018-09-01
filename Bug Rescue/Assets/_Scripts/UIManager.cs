using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIController {
    
    [SerializeField]
	private Text ScoreText;

    [SerializeField]
    private Canvas PauseMenu;

    private int _count = 0;


    public void Collectable() {
        _count++;
		ScoreText.text = _count.ToString ();
    }

    public void ShowPauseMenu() {
        print("called");
        PauseMenu.gameObject.SetActive(true);
    }

    public void HidePauseMenu() {
        PauseMenu.gameObject.SetActive(false);
    }
}
