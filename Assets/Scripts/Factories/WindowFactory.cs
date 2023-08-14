using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindowFactory
{
    [Inject] DiContainer _diContainer;
    public Window Create(File file, Vector3 position, Window previousWindow)
    {
        Window createdWindow = _diContainer
            .InstantiatePrefabForComponent<Window>(file.FileOpenedDisplay.gameObject, position, Quaternion.identity, null);

        if (previousWindow) 
            createdWindow.ShowFile(file, previousWindow);
        else 
            createdWindow.ShowFile(file);

        return createdWindow;
    }
}
