using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] Canvas _mainCanvas;
    [SerializeField] GameObject _folderDisplayed;
    [SerializeField] GameObject _folderOpened;
    int _topLayer = 3;
    Dictionary<GameObject, List<File>> _windowsFiles;


    public int TopLayer { get { return _topLayer; } set { _topLayer = value; } }
    public Canvas MainCanvas { get { return _mainCanvas; } }
    public GameObject FolderDisplayed { get { return _folderDisplayed; } }
    public GameObject FolderOpened { get { return _folderOpened; } }
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
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, -TopLayer / 900f);
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

    public void OpenFile(File file, Window containingWindow)
    {
        GameObject window;
        window = Instantiate(file.FileOpenedDisplay.gameObject, MainCanvas.transform, true);
        window.GetComponent<Window>().ShowFile(file, containingWindow);
    }
    public void OpenFile(File file)
    {
        GameObject window;
        window = Instantiate(file.FileOpenedDisplay.gameObject, MainCanvas.transform, true);
        window.GetComponent<Window>().ShowFile(file);
    }

}
