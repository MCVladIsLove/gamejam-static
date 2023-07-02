using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderBlocked : File
{
    [SerializeField] string _password;
    bool _blocked;

    public bool CheckPassword(string pass)
    {
        return _password == pass;
    }
    protected override void Awake()
    {
        _blocked = true;
        base.Awake();
    }

    public bool Blocked { get { return _blocked; } }
    public void Unlock()
    {
        _blocked = false;
        DisplayManager.Instance.RedrawOnlyAssociatedWindows(this);
    }
}
