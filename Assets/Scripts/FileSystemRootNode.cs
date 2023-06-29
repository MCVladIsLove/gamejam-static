using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystemRootNode : MonoBehaviour
{
    [SerializeField] DesktopWindow _desktop;

    public DesktopWindow Desktop { get { return _desktop; } }
}
