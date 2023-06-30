using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : MonoBehaviour
{
    // возможно нужен filepath, чтобы как раз он тут хранился и окошки могли от него обновлять путь в заголовках
    protected GameObject _display;
    protected GameObject _fileOpened;
    protected string _filePath;

    public string FilePath { get { return _filePath; } }
    public GameObject Display { get { return _display; } }
    public GameObject FileOpenedDisplay { get { return _fileOpened; } }
    public bool InRoot { get { return transform.parent.GetComponent<File>() == null; } }
    private void Awake()
    {
        _display = DisplayManager.Instance.FolderDisplayed;
        _fileOpened = DisplayManager.Instance.FolderOpened;
        UpdateFilePath();
    }
    public File[] GetChildren()
    {
        File[] nodes = new File[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            nodes[i] = transform.GetChild(i).GetComponent<File>();
        return nodes;
    }

    public void UpdateFilePath()
    {
        Transform parent = transform.parent;
        _filePath = name + "/";
        while (parent.TryGetComponent<FileSystemRootNode>(out FileSystemRootNode root) == false)
        {
            _filePath = parent.name + "/" + _filePath;
            parent = parent.parent;
        }
    }

    public File GetParent()
    {
        if (transform.parent.TryGetComponent<File>(out File parent))
            return parent;

        return null;
    }
}
