using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotepadWindow : Window
{
    [SerializeField] TextMeshPro _innerText;
    public override File OriginaFile => _originalFile;
    public override void ShowFile(File fileToOpen)
    {
        _originalFile = fileToOpen;
        Show(_originalFile);
        DisplayManager.Instance.DisplayOnNextLayer(gameObject);
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
