using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] Canvas _mainCanvas;
    [SerializeField] GameObject _folderDisplayed;
    int _topLayer = 3;
    Dictionary<GameObject, List<File>> _windowsFiles;


    public int TopLayer { get { return _topLayer; } set { _topLayer = value; } }
    public Canvas MainCanvas { get { return _mainCanvas; } }
    public GameObject FolderDisplayed { get { return _folderDisplayed; } }
    static public DisplayManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;

        _windowsFiles = new Dictionary<GameObject, List<File>>();
    }

    public void DisplayOnNextLayer(GameObject obj)
    {
        obj.GetComponent<SortingGroup>().sortingOrder = ++TopLayer;
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, obj.transform.localPosition.z - TopLayer / 900f);
    }

    public void BondFileWindow(GameObject window, File file)
    {
        if (!_windowsFiles.ContainsKey(window))
            _windowsFiles.Add(window, new List<File>());

        _windowsFiles[window].Add(file);
    }
    public void CloseWindow(GameObject window)
    {
        _windowsFiles.Remove(window);
        Destroy(window);
    }


}
