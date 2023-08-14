using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadDisplay : FileDisplay
{
    public override void Open()
    {
        _displayManager.OpenFile(_file);
    }

}
