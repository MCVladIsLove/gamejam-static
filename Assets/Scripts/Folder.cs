using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : Window
{
    List<File> _files;
    private void Awake()
    {
        _files = new List<File>();
    }

}
