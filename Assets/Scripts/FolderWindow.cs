using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FolderWindow : Window
{
    // Сделать нормально наследование. Добавить еще один смежный класс FolderTexted или типа того
    File _originalFile;

    //public GridPartition Grid { get { return _grid; } }
    public override void ShowFile(File fileToOpen)
    {
        _originalFile = fileToOpen;
        Show(_originalFile);
    }
 
    public override void Show(File file)
    {
        FileDisplay createdFile;
        _text.text += _originalFile.FilePath;
        int i = 0;
        foreach (File f in _originalFile.GetChildren())
        {
            DisplayManager.Instance.BondFileWindow(gameObject, f);
            createdFile = Instantiate(f.Display).GetComponent<FileDisplay>();
            createdFile.SetAssociatedFile(f);
            _grid.FillCell(i++, createdFile.gameObject);
            //createdFile.SetFilePath(_text.text + f.name);
        }
    }
}
