using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderInfected : File
{
    [SerializeField] GameObject _changeWhenWin;
    bool _infected;

    public bool Infected { get { return _infected; } }

    protected override void Awake()
    {
        _infected = true;
        base.Awake();
    }

    public void Cure()
    {
        _infected = false;
        _fileOpened = _changeWhenWin;
        DisplayManager.Instance.RedrawOnlyAssociatedWindows(this);
    }
}
