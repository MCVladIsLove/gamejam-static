using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioEditorWindow : Window
{
    [SerializeField] Canvas _interfaceCanvas;
    [SerializeField] TextMeshPro _audioName;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Slider _volume;
    [SerializeField] Slider _pitch;
    [SerializeField] Slider _noiseVolume;

    float _desiredNoiseVolume;
    protected override void Awake()
    {
        RandNoise();
        Instance = this;
        base.Awake();
    }
    static public AudioEditorWindow Instance { get; private set; }
    public override File OriginaFile { get { return _originalFile; } }

    public override void ShowFile(File fileToOpen)
    {
        _originalFile = fileToOpen;
        Show(_originalFile);
    }

    public override void Show(File file)
    {
        AudioEditor editor = (AudioEditor)_originalFile;
        _text.text = _originalFile.name;
        if (editor.OpenedAudio != null)
            _audioName.text = editor.OpenedAudio.name;
        else
            _audioName.text = "Ничего не играет";
        MoveHigherLayer();
    }

    public override void Redraw()
    {
        Show(_originalFile);
    }
    public override void MoveHigherLayer()
    {
        base.MoveHigherLayer();
        _interfaceCanvas.sortingOrder = DisplayManager.Instance.TopLayer;
    }

    private void OnDestroy()
    {
        AudioEditor editor = (AudioEditor)_originalFile;
        editor.Opened = false;
        if (editor.OpenedAudio != null)
        {
            editor.OpenedAudio.Stop();
            editor.SetAudio(null);
        }
        Instance = null;
    }

    public void PlayNoise()
    {
        _audioSource.Play();
    }
    public void StopNoise()
    {
        _audioSource.Stop();
    }

    public void OnVolumeChanged()
    {
        AudioEditor editor = (AudioEditor)_originalFile;
        if (editor.OpenedAudio != null)
            editor.OpenedAudio.AudioSource.volume = _volume.value;
    }
    public void OnPitchChanged()
    {
        AudioEditor editor = (AudioEditor)_originalFile;
        if (editor.OpenedAudio != null && !editor.OpenedAudio.Decrypted)
        {
            editor.OpenedAudio.AudioSource.pitch = (-10 + _pitch.value * 20 + editor.OpenedAudio.Shift) * (editor.OpenedAudio.Reversed ? -1 : 1);
            _audioSource.pitch = (-10 + _pitch.value * 20 + editor.OpenedAudio.Shift) * (editor.OpenedAudio.Reversed ? -1 : 1);
        }
    }

    public void OnNoiseVolumeChanged()
    {
        _audioSource.volume = Mathf.Abs(_noiseVolume.value * 16 - _desiredNoiseVolume);
    }

    public void RandNoise()
    {
        _desiredNoiseVolume = Random.value * 10 + 3;
    }

   
}
