using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Window : MonoBehaviour
{
    [SerializeField] GridPartition _grid;
    [SerializeField] TextMeshPro _text;
    FileDisplay _originalFile;

    //public GridPartition Grid { get { return _grid; } }
    public string FilePath { get { return _text.text; } }
    public void DisplayFile(FileDisplay fileToDisplay)
    {
        _originalFile = fileToDisplay;
        Init();
    }

    void Init()
    {
        FileDisplay createdFile;
        _text.text += _originalFile.Text.text + "/";
        int i = 0;
        foreach (FileDisplay f in _originalFile.Files)
        {
            createdFile = Instantiate(f);
            _grid.FillCell(i++, createdFile.gameObject);
            createdFile.SetFilePath(_text.text + f.FileName);
        }
    }
}
