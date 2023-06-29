using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Window : MonoBehaviour
{
    [SerializeField] protected GridPartition _grid;
    [SerializeField] protected TextMeshPro _text;


    public string FilePath { get { return _text.text; } }

    public virtual void ShowFile(File fileToOpen) { }

    public virtual void Show(File[] files)
    {
        FileDisplay createdFile;
        int i = 0;
        foreach (File f in files)
        {
            FileSystemManager.Instance.BondFileWindow(f, gameObject);
            createdFile = Instantiate(f.Display).GetComponent<FileDisplay>();
            createdFile.SetAssociatedFile(f);
            _grid.FillCell(i++, createdFile.gameObject);
            //createdFile.SetFilePath(f.name);
        }
    }
    public virtual void Show(File file) { }
    public virtual void Refresh() { }
    public virtual void SetPathPrefix(string prefix) { }

}