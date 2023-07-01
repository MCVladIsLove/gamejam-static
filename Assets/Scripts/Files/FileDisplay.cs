using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileDisplay : MonoBehaviour
{
    [SerializeField] TextMeshPro _text;
    [SerializeField] SpriteRenderer _spriteRenderer;
    File _file;

    public File AssociatedFile { get { return _file; } }
    public TextMeshPro Text { get { return _text; } }

    public virtual void Open() 
    {
        if (!_file.InRoot)
            DisplayManager.Instance.OpenFile(_file, GetComponentInParent<Window>());
        else
            DisplayManager.Instance.OpenFile(_file);
    }

    public void SetAssociatedFile(File file)
    {
        _file = file;
        Redraw();
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

    void Redraw()
    {
        _text.text = _file.name;
    }
}
