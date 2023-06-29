using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] Canvas _mainCanvas;

    int _topLayer = 3;

    public int TopLayer { get { return _topLayer; } set { _topLayer = value; } }
    public Canvas MainCanvas { get { return _mainCanvas; } }
    static public DisplayManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void DisplayOnNextLayer(GameObject obj)
    {
        obj.GetComponent<SortingGroup>().sortingOrder = ++DisplayManager.Instance.TopLayer;
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, obj.transform.localPosition.z - 1);
    }

}
