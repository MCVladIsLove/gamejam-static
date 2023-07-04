using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    [SerializeField] GameObject _noise;
    float _timePassed;
    bool _playing;
    static public Noise Instance { get; private set; }
    public bool Playing { get { return _playing; } set { _playing = value; } }

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;

        _playing = false;
    }
    static public void StartNoise(float maxSecondsDelay, int times, float maxLen, bool checkIfAlreadyPlaying)
    {
        if (checkIfAlreadyPlaying && !Instance.Playing || !checkIfAlreadyPlaying)
        {
            Instance.StartCoroutine(Instance.MakeNoise(maxSecondsDelay, times, maxLen));
            Instance.Playing = true;
        }
    }

    IEnumerator MakeNoise(float maxSecondsDelay, int times, float maxLen)
    {
        while (times > 0)
        {
            _playing = true;
            _noise.SetActive(true);
            yield return new WaitForSeconds(maxLen * Random.value);
            _noise.SetActive(false);
            yield return new WaitForSeconds(maxSecondsDelay * Random.value);
            times--;
        }
        _playing = false;
    }
}
