using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FileSystemManager : MonoBehaviour
{
    [SerializeField] FileSystemRootNode _fileSystemRoot;

   // Dictionary<File, GameObject> _filesDisplays;


    static public FileSystemManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        File[] desktopFiles = new File[_fileSystemRoot.transform.childCount];
        for (int i = 0; i < _fileSystemRoot.transform.childCount; i++)
            desktopFiles[i] = _fileSystemRoot.transform.GetChild(i).GetComponent<File>();
        _fileSystemRoot.Desktop.Show(desktopFiles);
      // DisplayManager.Instance.MainCanvas.transform.GetChild()
    }

}
