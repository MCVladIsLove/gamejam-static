using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDragArea : MonoBehaviour
{
    [SerializeField] Window _window;
    Vector3 _pointInWindow;
    Vector3 _mousePos;
    bool _isCaptured;

    private void Awake()
    {
        _isCaptured = false;
    }

    private void OnMouseDown()
    {
        _pointInWindow = HelpFunctions.GetMousePosWorld(_window.transform.position.z) - _window.transform.position;
        _window.MoveHigherLayer();
        _isCaptured = true;
    }
    private void Update()
    {
        if (_isCaptured)
        {
            _mousePos = HelpFunctions.GetMousePosWorld(_window.transform.position.z);
            _window.transform.position = _mousePos - _pointInWindow;
        }
    }

    private void OnMouseUp()
    {
        _isCaptured = false;
    }
}
