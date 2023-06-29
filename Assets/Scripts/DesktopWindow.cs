using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopWindow : MonoBehaviour
{
    [SerializeField] protected GridPartition _grid;

    public virtual void Show(File[] files)
    {
        FileDisplay createdFile;
        int i = 0;
        foreach (File f in files)
        {
            FileSystemManager.Instance.BondFileWindow(f, gameObject);
            createdFile = Instantiate(DisplayManager.Instance.FileDisplayed).GetComponent<FileDisplay>();
            createdFile.SetAssociatedFile(f);
            _grid.FillCell(i++, createdFile.gameObject);
            createdFile.SetFilePath(f.name);
        }
    }
}