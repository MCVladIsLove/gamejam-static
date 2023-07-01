using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmPassword : MonoBehaviour
{
    [SerializeField] TextMeshPro _text;

    public string Text { get { return _text.text; } }
    private void Update()
    {
        _text.text += Input.GetKeyDown(KeyCode.Alpha1) ? "1" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha2) ? "2" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha3) ? "3" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha4) ? "4" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha5) ? "5" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha6) ? "6" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha7) ? "7" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha8) ? "8" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha9) ? "9" : "";
        _text.text += Input.GetKeyDown(KeyCode.Alpha0) ? "0" : "";
        if (_text.text.Length > 4)
            _text.text = _text.text.Substring(0, 4);
    }
    private void OnEnable()
    {
        Clear();
    }

    public void Clear()
    {
        _text.text = "";
    }
}
