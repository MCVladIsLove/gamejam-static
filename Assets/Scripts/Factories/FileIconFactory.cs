using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FileIconFactory
{
    [Inject] DiContainer _diContainer;
    public FileDisplay Create(File file)
    {
        var fileDisplay = _diContainer
            .InstantiatePrefabForComponent<FileDisplay>(file.Display.gameObject);
        fileDisplay.SetAssociatedFile(file);
        return fileDisplay;
    }
}
