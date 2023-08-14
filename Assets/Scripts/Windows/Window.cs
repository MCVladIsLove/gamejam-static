using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class Window : MonoBehaviour
{
    [SerializeField] protected GridPartition _grid;
    [SerializeField] protected TextMeshPro _text;
    
    protected File _originalFile;

    [Inject] protected DisplayManager _displayManager;
    [Inject] protected FileIconFactory _fileIconFactory;

    public virtual File OriginalFile { get { return null; } }
    public string FilePath { get { return _text.text; } }
    public GridPartition Grid { get { return _grid; } }

    protected virtual void Awake()
    {
        _displayManager.TrackWindow(this);
    }
    public virtual void ShowFile(File fileToOpen) { }
    public virtual void ShowFile(File fileToOpen, Window previousWindow) { }

    public virtual void Show(File[] files)
    {
        FileDisplay createdFile;
        int i = 0;
        foreach (File f in files)
        {
            _displayManager.BondFileWindow(gameObject, f);
            createdFile = _fileIconFactory.Create(f);
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
        _displayManager.DisplayOnNextLayer(gameObject);
    }
}