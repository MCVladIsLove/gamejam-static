using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    RectTransform _cellRect;
    BoxCollider2D _collider;
    public bool IsOccupied { get; set; }

    public void Init(Transform parent, Vector2 scale, Vector3 centerPosition)
    {
        _cellRect = GetComponent<RectTransform>();
        _collider = GetComponent<BoxCollider2D>();
        transform.SetParent(parent, false);
        _cellRect.sizeDelta = scale;
        //cellRect.localScale = scale;
        _cellRect.anchoredPosition = centerPosition;
        _collider.size = scale;
        IsOccupied = false;
    }

    public void Fill(GameObject filler)
    {
        filler.transform.SetParent(transform, false);
        IsOccupied = true;
    }
    public GameObject Filer { get {
            if (transform.childCount > 0)
                return transform.GetChild(0).gameObject;
            else
                return null;
        } }
}
