using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class File : MonoBehaviour
{
    [SerializeField] List<File> _files;
    [SerializeField] string _name;
    [SerializeField] TextMeshPro _text;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Window _openedFolder;
    string _filePath;

    public TextMeshPro Text { get { return _text; } }
    public File[] Files { get { return _files.ToArray(); } }
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
            GetComponentInParent<Window>().DisplayFile(this);
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
}
