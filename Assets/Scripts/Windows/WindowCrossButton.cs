using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindowCrossButton : MonoBehaviour
{
    [SerializeField] Window _window;
    [SerializeField] Color _overColor;
    [Inject] private DisplayManager _displayManager;

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
        _displayManager.CloseWindow(_window.gameObject);
        SoundManager.Instance.Play(SoundManager.Instance.FileClose);
    }
}
