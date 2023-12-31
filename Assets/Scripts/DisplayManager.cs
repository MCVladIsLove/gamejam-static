using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class DisplayManager : MonoBehaviour
{
    [Inject] WindowFactory _windowFactory;

    private int _topLayer = 3;
    private Dictionary<GameObject, List<File>> _windowsFiles;


    public int TopLayer { get { return _topLayer; } set { _topLayer = value; } }
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
    public void TrackWindow(Window window)
    {
        _windowsFiles.Add(window.gameObject, new List<File>());
    }

    public void CloseWindow(GameObject window)
    {
        _windowsFiles.Remove(window);
        Destroy(window);
    }

    public void OpenFile(File file, Window containingWindow)
    {
        _windowFactory.Create(file, Vector3.zero, containingWindow);
    }
    public void OpenFile(File file)
    {
        _windowFactory.Create(file, Vector3.zero, null);
    }
    public void RedrawWindows(File root)
    {
        LinkedList<Window> windowsToRedraw = new LinkedList<Window>();
        Window window;


        foreach (var w in _windowsFiles)
        {
            window = w.Key.GetComponent<Window>();
            if (FileSystemManager.Instance.FileInsideWindow(window, root) && window.OriginalFile != null)
                windowsToRedraw.AddLast(window);
            else if (window.OriginalFile == root)
                windowsToRedraw.AddLast(window);
        }


        foreach (var f in root.GetChildren())
            RedrawWindow(windowsToRedraw, f);

        foreach (Window w in windowsToRedraw)
            w.Redraw();// OpenFile(w.OriginaFile, w);
    }

    void RedrawWindow(LinkedList<Window> windowsToRedraw, File root)
    {
        Window window;

        if (root.transform.childCount == 0)
        {
            foreach (var w in _windowsFiles)
            {
                window = w.Key.GetComponent<Window>();
                if (window.OriginalFile == root)
                    windowsToRedraw.AddLast(window);
            }
        }
        else
        {
            foreach (var w in _windowsFiles)
            {
                window = w.Key.GetComponent<Window>();
                if (FileSystemManager.Instance.FileInsideWindow(window, root) && window.OriginalFile != null)
                    if (!windowsToRedraw.Contains(window))
                        windowsToRedraw.AddLast(window);
            }
        }

        foreach (var f in root.GetChildren())
            RedrawWindow(windowsToRedraw, f);
    }
    public void DetachFile(File file)
    {
        foreach (var w in _windowsFiles)
        {
            if (w.Value.Contains(file))
                _windowsFiles[w.Key].Remove(file);
        }
    }
    public void DetachFileAndRedrawWindow(File file)
    {
        LinkedList<Window> windowsToRedraw = new LinkedList<Window>();
        foreach (var w in _windowsFiles)
        {
            if (w.Value.Contains(file))
            {
                _windowsFiles[w.Key].Remove(file);
                Window window = w.Key.GetComponent<Window>();
                if (window.OriginalFile != null)
                    windowsToRedraw.AddLast(window);
            }
        }
        foreach (Window w in windowsToRedraw)
            w.Redraw();
            //OpenFile(w.OriginaFile, w);
    }

    public void RedrawOnlyAssociatedWindows(File file)
    {
        LinkedList<Window> windowsToRedraw = new LinkedList<Window>();
        foreach (var w in _windowsFiles)
        {
            if (w.Value.Contains(file))
            {
                Window window = w.Key.GetComponent<Window>();
                if (window.OriginalFile != null)
                    windowsToRedraw.AddLast(window);
            }
        }
        foreach (Window w in windowsToRedraw)
            w.Redraw();

        RedrawDesktopIcons();
    }

    public void RedrawDesktopIcons()
    {
        foreach (var w in _windowsFiles)
        {
            if (w.Key.name == "Desktop")
            {
                Window window = w.Key.GetComponent<Window>();
                for (int i = 0; i < window.Grid.Capacity; i++)
                    window.Grid.GetCell(i).Filer?.GetComponent<FileDisplay>().Redraw();
                break;
            }
        }
    }

}
