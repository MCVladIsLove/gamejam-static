using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFolder : FileDisplay
{
    bool _endEverything;
    float _timer;
    protected override void OnMouseUpAsButton()
    {
        _endEverything = true;
        Noise.StartNoise(0.2f, 10, 1, false);
    }
    private void Update()
    {
        if (_timer > 4)
            Application.Quit();
        if (_endEverything)
        { 
            _timer += Time.deltaTime;
        }
        else
            Noise.StartNoise(5f, 4, 0.4f, true);
    }
}
