using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEditorPlayPause : MonoBehaviour
{
    bool _playing;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite _play;
    [SerializeField] Sprite _pause;
    [SerializeField] AudioEditorWindow _audioEditor;
    private void Awake()
    {
        _playing = false;
    }
    protected virtual void OnMouseEnter()
    {
        _spriteRenderer.transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }
    protected virtual void OnMouseExit()
    {
        _spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnMouseUpAsButton()
    {
        AudioEditor editorFile = (AudioEditor)_audioEditor.OriginaFile;
        if (editorFile.OpenedAudio != null)
        {
            if (_playing)
            {
                editorFile.OpenedAudio.Stop();
                _spriteRenderer.sprite = _play;
                _audioEditor.StopNoise();
            }
            else
            {
                editorFile.OpenedAudio.Play();
                if (!editorFile.OpenedAudio.Decrypted)
                    _audioEditor.PlayNoise();
                _spriteRenderer.sprite = _pause;
            }
            _playing  = !_playing;
        }
    }
}
