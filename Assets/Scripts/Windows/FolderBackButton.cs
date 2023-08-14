using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FolderBackButton : MonoBehaviour
{
    [SerializeField] Window _window;
    [SerializeField] Color _overColor;
    [Inject] private DisplayManager _displayManager;

    private void OnMouseEnter()
    {
        if (_window.OriginalFile.GetParent() != null)
            GetComponent<SpriteRenderer>().color = _overColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    private void OnMouseUpAsButton()
    {
        File parent = _window.OriginalFile.GetParent();
        if (parent != null)
            _displayManager.OpenFile(parent, GetComponentInParent<Window>());
    }
}
