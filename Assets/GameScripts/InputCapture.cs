using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InputPositionEvent : UnityEvent<Vector3> { }
[System.Serializable]
public class InputEvent : UnityEvent{ }

public class InputCapture : MonoBehaviour
{
    public InputPositionEvent onInitialPress = new InputPositionEvent();
    public InputEvent onRelease = new InputEvent();
    public InputPositionEvent onHeld = new InputPositionEvent();
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) onInitialPress.Invoke(Input.mousePosition);
        if(Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0)) onHeld.Invoke(Input.mousePosition);
        if(Input.GetMouseButtonUp(0)) onRelease.Invoke();
    }
}
