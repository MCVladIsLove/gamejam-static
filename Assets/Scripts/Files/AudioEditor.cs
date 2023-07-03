using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEditor : File
{
    bool _opened;
    AudioFile _openedAudio;

    public AudioFile OpenedAudio { get { return _openedAudio; } }
    public bool Opened { get { return _opened; } set { _opened = value; } }
    protected override void Awake()
    {
        _opened = false;
        base.Awake();
    }

    public void SetAudio(AudioFile audio)
    {
        _openedAudio = audio;
    }
}
