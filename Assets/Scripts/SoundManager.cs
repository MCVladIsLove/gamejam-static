using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _source;


    [SerializeField] AudioClip _glitch;
    [SerializeField] AudioClip _bombBang;
    [SerializeField] AudioClip _unlockFolder;
    [SerializeField] AudioClip _fileClose;
    [SerializeField] AudioClip _click;
    [SerializeField] AudioClip _fileOpen;
    [SerializeField] AudioClip _infectedArkanoidBlockCollision;
    [SerializeField] AudioClip _arkanoidPlateHit;
    public AudioClip Glitch { get { return _glitch; } }
    public AudioClip BombBang { get { return _bombBang; } }
    public AudioClip UnlockFolder { get { return _unlockFolder; } }
    public AudioClip FileClose { get { return _fileClose; } }
    public AudioClip Click { get { return _click; } }
    public AudioClip FileOpen { get { return _fileOpen; } }
    public AudioClip InfectedArkanoidBlockCollision { get { return _infectedArkanoidBlockCollision; } }
    public AudioClip ArkanoidPlateHit { get { return _arkanoidPlateHit; } }

    static public SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void Play(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
    public void Play(AudioClip clip, float volume)
    {
        _source.PlayOneShot(clip, volume);
    }

}
