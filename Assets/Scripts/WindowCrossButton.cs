using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCrossButton : MonoBehaviour
{
    [SerializeField] Window _window;

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 15);
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }
    private void OnMouseUpAsButton()
    {
        
    }
}
