using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadFile : File
{
    [SerializeField, TextArea] string _innerText;

    public string InnerText { get { return _innerText; } }
}
