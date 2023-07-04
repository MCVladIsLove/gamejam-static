using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Window : MonoBehaviour
{
    [SerializeField] protected GridPartition _grid;
    [SerializeField] protected TextMeshPro _text;
    protected File _originalFile;

    public virtual File OriginaFile { get { return null; } }
    public string FilePath { get { return _text.text; } }
    public GridPartition Grid { get { return _grid; } }

    protected virtual void Awake()
    {
        DisplayManager.Instance.TrackWindow(this);
    }
    public virtual void ShowFile(File fileToOpen) { }
    public virtual void ShowFile(File fileToOpen, Window previousWindow) { }

    public virtual void Show(File[] files)
    {
        FileDisplay createdFile;
        int i = 0;
        foreach (File f in files)
        {
            DisplayManager.Instance.BondFileWindow(gameObject, f);
            createdFile = Instantiate(f.Display).GetComponent<FileDisplay>();
            createdFile.SetAssociatedFile(f);
            _grid.FillCell(i++, createdFile.gameObject);
            //createdFile.SetFilePath(f.name);
        }
    }
    public virtual void Show(File file) { }
    public virtual void Redraw() 
    {
    }

    public virtual void MoveHigherLayer()
    {
        DisplayManager.Instance.DisplayOnNextLayer(gameObject);
    }
}