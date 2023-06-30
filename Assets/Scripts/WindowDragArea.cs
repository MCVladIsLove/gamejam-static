using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDragArea : MonoBehaviour
{
    [SerializeField] Window _window;
    Camera _camera;
    Vector3 _pointInWindow;
    Vector3 _mousePos;
    bool _isCaptured;

    private void Awake()
    {
        _camera = MainCamera.cam;
        _isCaptured = false;
    }

    private void OnMouseDown()
    {
        _pointInWindow = GetMousePosWorld() - _window.transform.position;
        _isCaptured = true;
    }
    private void Update()
    {
        if (_isCaptured)
        {
            _mousePos = GetMousePosWorld();
            _window.transform.position = _mousePos - _pointInWindow;
        }
    }

    private void OnMouseUp()
    {
        _isCaptured = false;
    }

    Vector3 _tmpVec;
    Vector3 GetMousePosWorld()
    {
        _tmpVec = _camera.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        return new Vector3(_tmpVec.x, _tmpVec.y, _window.transform.position.z);
    }
}
