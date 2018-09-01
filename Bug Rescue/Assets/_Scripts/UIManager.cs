using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIController {
    private int _count = 0;
	public Text tex;

    public void Collectable() {
        _count++;
		tex.text = _count.ToString ();
        print("count: " + _count);
    }
}
