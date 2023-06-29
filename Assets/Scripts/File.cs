using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : MonoBehaviour
{
    // возможно нужен filepath, чтобы как раз он тут хранился и окошки могли от него обновлять путь в заголовках
    protected GameObject _display;
    public GameObject Display { get { return _display; } }
    public bool InRoot { get { return transform.parent.GetComponent<File>() == null; } }
    private void Awake()
    {
        _display = DisplayManager.Instance.FolderDisplayed;
    }
    public File[] GetChildren()
    {
        File[] nodes = new File[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            nodes[i] = transform.GetChild(i).GetComponent<File>();
        return nodes;
    }

}
