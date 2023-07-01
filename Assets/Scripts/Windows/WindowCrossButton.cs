using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCrossButton : MonoBehaviour
{
    [SerializeField] Window _window;
    [SerializeField] Color _overColor;

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = _overColor;
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }
    private void OnMouseUpAsButton()
    {
        DisplayManager.Instance.CloseWindow(_window.gameObject);
    }
}
