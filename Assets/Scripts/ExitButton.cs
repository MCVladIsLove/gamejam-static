using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] Image _image;
    protected virtual void OnMouseEnter()
    {
        _image.transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }
    protected virtual void OnMouseExit()
    {
        _image.transform.localScale = new Vector3(1, 1, 1);
    }
    protected virtual void OnMouseUpAsButton()
    {
        Application.Quit();
    }
}
