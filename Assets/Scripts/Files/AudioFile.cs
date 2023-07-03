using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFile : File
{
    bool _decrypted;
    bool _playing;

    public bool Reversed { get { return _reversed; } }

    [SerializeField] float _shift;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] bool _reversed;

    public AudioClip Audio { get { return _audioSource.clip; } }
    public AudioSource AudioSource { get { return _audioSource; } }
    public bool Decrypted { get { return _decrypted; } } 
    public bool Playing { get { return _playing; } }
    public float Shift { get { return _shift; } }
    protected override void Awake()
    {
        _decrypted = false;
        _playing = false;
        base.Awake();
    }

    public void Play()
    {
        _audioSource.Play();
        _playing = true;
    }
    public void Stop()
    {
        _audioSource.Stop();
        _playing = false;
    }
    public void Decrypt()
    {
        _decrypted = true;
    }
}
