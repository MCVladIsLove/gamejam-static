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
        else
            Noise.StartNoise(0.3f, 6, 0.3f, false);
        // ТУТ БУДЕТ ШАКАЛИТЬ ЭКРАН КРУТО
    }
}
