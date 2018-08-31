using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIController {
    private int _count = 0;

    public void Collectable() {
        _count++;
        print("count: " + _count);
    }
}
