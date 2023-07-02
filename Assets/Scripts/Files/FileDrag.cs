using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDrag : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _sprite;
    protected File _file;
    protected Vector3 _pointInWindow;
    protected Vector3 _mousePos;
    protected bool _isCaptured;
    protected SpriteRenderer _ghostFile;

    protected virtual void Start()
    {
        _file = gameObject.GetComponent<FileDisplay>().AssociatedFile;
        _isCaptured = false;
    }

    protected virtual void OnMouseDown()
    {
        _ghostFile = Instantiate(_sprite);
        _ghostFile.color = new Color(255, 255, 255, 0.4f);
        _ghostFile.sortingOrder = DisplayManager.Instance.TopLayer+1;
        _pointInWindow = HelpFunctions.GetMousePosWorld(transform.position.z) - transform.position;
        _isCaptured = true;
    }
    protected virtual void Update()
    {
        if (_isCaptured)
        {
            _mousePos = HelpFunctions.GetMousePosWorld(transform.position.z);
            _ghostFile.transform.position = _mousePos - _pointInWindow;
        }
    }

    protected virtual void OnMouseUp()
    {
        Collider2D collider = Physics2D.GetRayIntersection(MainCamera.cam.ScreenPointToRay(Input.mousePosition)).collider;
        if (collider.TryGetComponent<GridCell>(out GridCell cell) && cell.IsOccupied == false)
        {
            Window window = cell.GetComponentInParent<Window>();
            if (window.OriginaFile == null || !window.OriginaFile.transform.IsChildOf(_file.transform))   
            {
                if (window == gameObject.GetComponentInParent<Window>())
                {
                    GetComponentInParent<GridCell>().IsOccupied = false;
                    cell.Fill(gameObject);
                }
                else if (!FileSystemManager.Instance.FileInsideWindow(window, _file))
                {
                    GetComponentInParent<GridCell>().IsOccupied = false;
                    cell.Fill(gameObject);
                    FileSystemManager.Instance.MoveFileTo(_file, window.OriginaFile);
                    DisplayManager.Instance.DetachFileAndRedrawWindow(_file);
                    DisplayManager.Instance.BondFileWindow(window.gameObject, _file);
                    DisplayManager.Instance.RedrawWindows(_file);
                }
            }
        }
        Destroy(_ghostFile.gameObject);
        _isCaptured = false;
    }
}
