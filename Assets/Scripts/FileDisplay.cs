using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileDisplay : MonoBehaviour
{
    [SerializeField] List<FileDisplay> _files;
    [SerializeField] string _name;
    [SerializeField] TextMeshPro _text;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Window _openedFolder;
    File _file;
    string _filePath;

    public File AssociatedFile { get { return _file; } }
    public TextMeshPro Text { get { return _text; } }
    public FileDisplay[] Files { get { return _files.ToArray(); } }
    public string FileName { get { return _name; } }
    private void Awake()
    {
        _filePath = "";
        _text.text = _name;
    }

    public virtual void Open() 
    {
        if (_filePath == "")
        {
            GameObject folder = Instantiate(_openedFolder.gameObject, DisplayManager.Instance.MainCanvas.transform, true);
            folder.GetComponent<Window>().DisplayFile(this);
            DisplayManager.Instance.DisplayOnNextLayer(folder);
        }
        else
        { 
            GetComponentInParent<Window>().DisplayFile(this);
        }
    }

    public void SetAssociatedFile(File file)
    {
        _file = file;
        Refresh();
    }
    public void SetFilePath(string path)
    {
        _filePath = path;
    }

    private void OnMouseEnter()
    {
        _spriteRenderer.transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }
    private void OnMouseExit()
    {
        _spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
    }
    private void OnMouseUpAsButton()
    {
        Open();
    }

    void Refresh()
    {
        _text.text = _file.name;
    }
}
