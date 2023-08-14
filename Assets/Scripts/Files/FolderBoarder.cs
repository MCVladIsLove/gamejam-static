using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FolderBoarder : File
{
    bool _boarder;
    [Inject] DisplayManager _displayManager;

    protected override void Awake()
    {
        _boarder = true;
        base.Awake();
    }
    public bool Boarder { get { return _boarder; } }
    public void Unlock()
    {
        _boarder = false;
        _displayManager.RedrawOnlyAssociatedWindows(this);
    }

}
