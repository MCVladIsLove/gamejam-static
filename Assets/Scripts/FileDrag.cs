using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDrag : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sprite;
    Vector3 _pointInWindow;
    Vector3 _mousePos;
    bool _isCaptured;
    GameObject _ghostFile;

    private void Awake()
    {
        _isCaptured = false;
    }

    private void OnMouseDown()
    {
        _ghostFile = Instantiate(_sprite.gameObject);
        _ghostFile.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.4f);
        _ghostFile.GetComponent<SpriteRenderer>().sortingOrder = DisplayManager.Instance.TopLayer+1;
        _pointInWindow = HelpFunctions.GetMousePosWorld(transform.position.z) - transform.position;
        _isCaptured = true;
    }
    private void Update()
    {
        if (_isCaptured)
        {
            _mousePos = HelpFunctions.GetMousePosWorld(transform.position.z);
            _ghostFile.transform.position = _mousePos - _pointInWindow;
        }
    }

    private void OnMouseUp()
    {
        Collider2D collider = Physics2D.GetRayIntersection(MainCamera.cam.ScreenPointToRay(Input.mousePosition)).collider;
        if (collider.TryGetComponent<GridCell>(out GridCell cell) && cell.IsOccupied == false)
        {
            GetComponentInParent<GridCell>().IsOccupied = false;
            cell.Fill(gameObject);
        }
        Destroy(_ghostFile);
        _isCaptured = false;
    }
}
