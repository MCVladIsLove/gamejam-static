using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEditorWindow : Window
{
    [SerializeField] Canvas _interfaceCanvas;

    public override File OriginaFile { get { return _originalFile; } }

    public override void ShowFile(File fileToOpen)
    {
        _originalFile = fileToOpen;
        Show(_originalFile);
    }

    public override void Show(File file)
    {
        AudioEditor editor = (AudioEditor)_originalFile;
        _text.text = _originalFile.name + (editor.OpenedAudio != null ? ": " + editor.OpenedAudio.name : "");
        MoveHigherLayer();
    }

    public override void Redraw()
    {
        Show(_originalFile);
    }
    public override void MoveHigherLayer()
    {
        base.MoveHigherLayer();
        _interfaceCanvas.sortingOrder = DisplayManager.Instance.TopLayer;
    }

    private void OnDestroy()
    {
        AudioEditor editor = (AudioEditor)_originalFile;
        editor.Opened = false;
        editor.SetAudio(null);
    }
}
