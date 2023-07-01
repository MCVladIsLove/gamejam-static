using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : MonoBehaviour
{
    [SerializeField] protected GameObject _display;
    [SerializeField] protected GameObject _fileOpened;
    protected string _filePath;

    public string FilePath { get { return _filePath; } set { _filePath = value; } }
    public GameObject Display { get { return _display; } }
    public GameObject FileOpenedDisplay { get { return _fileOpened; } }
    public bool InRoot { get { return transform.parent.GetComponent<File>() == null; } }
    protected virtual void Awake()
    {
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
