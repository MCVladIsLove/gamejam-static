using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Window : MonoBehaviour
{
    [SerializeField] GridPartition _grid;
    [SerializeField] TextMeshPro _text;
    File _originalFile;

    //public GridPartition Grid { get { return _grid; } }
    public string FilePath { get { return _text.text; } }
    public void DisplayFile(File fileToDisplay)
    {
        _originalFile = fileToDisplay;
        Init();
    }

    void Init()
    {
        _text.text += _originalFile.Text.text + "/";
        int i = 0;
        foreach (File f in _originalFile.Files)
            _grid.FillCell(i++, Instantiate(f).gameObject);
    }
}
