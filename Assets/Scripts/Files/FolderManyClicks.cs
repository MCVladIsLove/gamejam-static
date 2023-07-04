using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderManyClicks : File
{
    [SerializeField] int _clicks;

    public int ClicksLeft { get { return _clicks; } }
    public void Click()
    {
        _clicks--;
    }
}
