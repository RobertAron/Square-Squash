using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[System.Serializable]
public class InputPositionEvent : UnityEvent<Vector3> { }
[System.Serializable]
public class InputEvent : UnityEvent{ }

public class InputCapture : MonoBehaviour
{
    public InputPositionEvent onInitialPress = new InputPositionEvent();
    public InputEvent onRelease = new InputEvent();
    public InputPositionEvent onHeld = new InputPositionEvent();
    GameOverController gameOverController;

    private void Start() {
        gameOverController = GameOverController.instance;
    }

    void Update()
    {
        if(!gameOverController.IsGameOver())
        {
            if(Input.GetMouseButtonDown(0)) onInitialPress.Invoke(Input.mousePosition);
            if(Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0)) onHeld.Invoke(Input.mousePosition);
            if(Input.GetMouseButtonUp(0)) onRelease.Invoke();
        }
    }
}
