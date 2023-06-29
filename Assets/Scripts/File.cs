using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : MonoBehaviour
{
    public File[] GetChildren()
    {
        File[] nodes = new File[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            nodes[i] = transform.GetChild(i).GetComponent<File>();
        return nodes;
    }

}
