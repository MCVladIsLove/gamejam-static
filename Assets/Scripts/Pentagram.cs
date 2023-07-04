using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour
{
    float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1.5f)
            Destroy(gameObject);
    }
}
