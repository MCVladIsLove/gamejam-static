using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileDisplay : MonoBehaviour
{
    [SerializeField] protected TextMeshPro _text;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected File _file;

    public File AssociatedFile { get { return _file; } }
    public TextMeshPro Text { get { return _text; } }
    public Sprite Sprite { get { return _spriteRenderer.sprite; } }

    protected virtual void Awake()
    { }
    public virtual void Open() 
    {
        if (!_file.InRoot)
            DisplayManager.Instance.OpenFile(_file, GetComponentInParent<Window>());
        else
            DisplayManager.Instance.OpenFile(_file);
    }

    public virtual void SetAssociatedFile(File file)
    {
        _file = file;
        Redraw();
    }

    protected virtual void OnMouseEnter()
    {
        _spriteRenderer.transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }
    protected virtual void OnMouseExit()
    {
        _spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
    }
    protected virtual void OnMouseUpAsButton()
    {
        Open();
        SoundManager.Instance.Play(SoundManager.Instance.FileOpen);
    }

    public virtual void Redraw()
    {
        _text.text = _file.name;
    }
}
