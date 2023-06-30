using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderBackButton : MonoBehaviour
{
    [SerializeField] Window _window;
    [SerializeField] Color _overColor;

    private void OnMouseEnter()
    {
        if (_window.OriginaFile.GetParent() != null)
            GetComponent<SpriteRenderer>().color = _overColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    private void OnMouseUpAsButton()
    {
        File parent = _window.OriginaFile.GetParent();
        if (parent != null)
            DisplayManager.Instance.OpenFile(parent, GetComponentInParent<Window>());
    }
}
