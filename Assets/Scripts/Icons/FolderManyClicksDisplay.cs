using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderManyClicksDisplay : FileDisplay
{
    protected override void OnMouseUpAsButton()
    {
        FolderManyClicks folder = (FolderManyClicks)_file;
        folder.Click();
        if (folder.ClicksLeft <= 0)
            base.OnMouseUpAsButton();
        // ТУТ БУДЕТ ШАКАЛИТЬ ЭКРАН КРУТО
    }
}
