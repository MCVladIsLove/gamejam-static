using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FolderInfected : File
{
    [SerializeField] GameObject _changeWhenWin;
    bool _infected;
    [Inject] DisplayManager _displayManager;
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
        _displayManager.RedrawOnlyAssociatedWindows(this);
    }
}
