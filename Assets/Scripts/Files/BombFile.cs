using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFile : File
{
    [SerializeField] float _boomDuration = 2.5f;

    public float BoomDuration { get { return _boomDuration; } }
    public void Boom()
    {

    }
}
