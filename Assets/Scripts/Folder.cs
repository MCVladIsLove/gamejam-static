using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : FolderWindow
{
    List<FileDisplay> _files;
    private void Awake()
    {
        _files = new List<FileDisplay>();
    }

}
