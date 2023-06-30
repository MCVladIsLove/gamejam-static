using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileDisplay : MonoBehaviour
{
    [SerializeField] TextMeshPro _text;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] FolderWindow _openedFolder;
    File _file;

    public File AssociatedFile { get { return _file; } }
    public TextMeshPro Text { get { return _text; } }

    public virtual void Open() 
    {
        GameObject window;
        window = Instantiate(_openedFolder.gameObject, DisplayManager.Instance.MainCanvas.transform, true);
        window.GetComponent<Window>().ShowFile(_file);

        if (!_file.InRoot)
        {
            Window parent = GetComponentInParent<Window>();
            window.transform.position = parent.transform.position;
            DisplayManager.Instance.CloseWindow(parent.gameObject);
        }

        DisplayManager.Instance.DisplayOnNextLayer(window);
    }

    public void SetAssociatedFile(File file)
    {
        _file = file;
        Refresh();
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
