using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FolderWindow : Window
{
    // Сделать нормально наследование. Добавить еще один смежный класс FolderTexted или типа того
    public override File OriginalFile { get { return _originalFile; } }

    //public GridPartition Grid { get { return _grid; } }
    public override void ShowFile(File fileToOpen)
    {
        _originalFile = fileToOpen;
        Show(_originalFile);
        MoveHigherLayer();
    }

    public override void ShowFile(File fileToOpen, Window previousWindow)
    {
        _originalFile = fileToOpen;
        Show(_originalFile);
        transform.position = previousWindow.transform.position;
        _displayManager.CloseWindow(previousWindow.gameObject);
        MoveHigherLayer();
    }


    public override void Show(File file)
    {
        FileDisplay createdFile;
        _text.text += _originalFile.FilePath;
        int i = 0;
        foreach (File f in _originalFile.GetChildren())
        {
            _displayManager.BondFileWindow(gameObject, f);
            createdFile = _fileIconFactory.Create(f);
            _grid.FillCell(i++, createdFile.gameObject);
            //createdFile.SetFilePath(_text.text + f.name);
        }
    }
    public override void Redraw()
    {
        _displayManager.OpenFile(_originalFile, this);
    }
}
