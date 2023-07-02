using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderBoarder : File
{
    bool _boarder;

    protected override void Awake()
    {
        _boarder = true;
        base.Awake();
    }
    public bool Boarder { get { return _boarder; } }
    public void Unlock()
    {
        _boarder = false;
        DisplayManager.Instance.RedrawOnlyAssociatedWindows(this);
    }

}
