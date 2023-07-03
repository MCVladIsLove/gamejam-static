using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEditorDislpay : FileDisplay
{
    public override void Open()
    {
        DisplayManager.Instance.OpenFile(_file);
    }

    protected override void OnMouseUpAsButton()
    {
        AudioEditor file = (AudioEditor)_file;
        if (!file.Opened)
        {
            base.OnMouseUpAsButton();
            file.Opened = true;
        }
    }
}
