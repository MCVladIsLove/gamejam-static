using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotepadWindow : Window
{
    [SerializeField] TextMeshPro _innerText;
    public override File OriginalFile => _originalFile;
    public override void ShowFile(File fileToOpen)
    {
        _originalFile = fileToOpen;
        Show(_originalFile);
        MoveHigherLayer();
    }

    public override void Show(File file)
    {
        _text.text = _originalFile.name;
        NotepadFile notepad = (NotepadFile)_originalFile;
        _innerText.text = notepad.InnerText;
    }

    public override void Redraw()
    {
        Show(_originalFile);
    }
}
