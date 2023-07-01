using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FileSystemManager : MonoBehaviour
{
    [SerializeField] FileSystemRootNode _fileSystemRoot;

   // Dictionary<File, GameObject> _filesDisplays;

    public FileSystemRootNode FileSystemRoot { get { return _fileSystemRoot; } }
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

    public void UpdateFilePaths(File root)
    {
        if (root.transform.parent.TryGetComponent<File>(out File parent))
            root.FilePath = parent.FilePath + root.name + "/";
        else
            root.FilePath = root.name + "/";

        UpdatePath(root);
    }
    private void UpdatePath(File file)
    {
        foreach (File f in file.GetChildren())
        {
            f.FilePath = file.FilePath + f.name + "/";
            UpdatePath(f);
        }
    }
    public void MoveFileTo(File file, File where)
    {
        if (where == null)
        {
            file.transform.SetParent(_fileSystemRoot.transform);
        }
        else
            file.transform.SetParent(where.transform);

        UpdateFilePaths(file);
    }

    public bool FileInsideWindow(Window window, File file)
    {
        if (window.OriginaFile == null && file.InRoot)
            return true;
        else if (window.OriginaFile != null)
            return file.transform.parent.gameObject == window.OriginaFile.gameObject;
        else
            return false;

    }
}
