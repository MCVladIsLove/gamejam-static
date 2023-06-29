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
        _text.text += _originalFile.name + "/";
        int i = 0;
        foreach (File f in _originalFile.GetChildren())
        {
            FileSystemManager.Instance.BondFileWindow(f, gameObject);
            createdFile = Instantiate(f.Display).GetComponent<FileDisplay>();
            createdFile.SetAssociatedFile(f);
            _grid.FillCell(i++, createdFile.gameObject);
            //createdFile.SetFilePath(_text.text + f.name);
        }
    }

    public override void SetPathPrefix(string prefix)
    {
        _text.text = prefix + _text.text;
    }
}
