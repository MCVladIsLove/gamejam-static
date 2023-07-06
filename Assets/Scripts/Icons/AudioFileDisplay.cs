using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFileDisplay : FileDisplay
{
    protected override void OnMouseUpAsButton()
    {
        Open();
    }
    public override void Open()
    {
        if (AudioEditorWindow.Instance != null)
        {
            if (AudioEditorPlayPause._playing)
            {
                AudioEditor auEditor = (AudioEditor)AudioEditorWindow.Instance.OriginaFile;
                auEditor.OpenedAudio.Stop();
                AudioEditorPlayPause.Instance._spriteRenderer.sprite = AudioEditorPlayPause.Instance._play;
                AudioEditorWindow.Instance.StopNoise();
                AudioEditorPlayPause._playing = false;
                AudioEditorWindow.Instance.RandNoise();
            }

            AudioEditor editor = (AudioEditor)AudioEditorWindow.Instance.OriginaFile;
            AudioFile audio = (AudioFile)_file;
            editor.SetAudio(audio);
            AudioEditorWindow.Instance.OnPitchChanged();
            AudioEditorWindow.Instance.OnVolumeChanged();
            AudioEditorWindow.Instance.OnNoiseVolumeChanged();
            AudioEditorWindow.Instance.Redraw();
        }
        /*if (AudioEditorWindow.Instance != null)
        {
            AudioEditor editor = (AudioEditor)AudioEditorWindow.Instance.OriginaFile;
            AudioFile audio = (AudioFile)_file;
            editor.SetAudio(audio);
            AudioEditorWindow.Instance.OnPitchChanged();
            AudioEditorWindow.Instance.OnVolumeChanged();
            AudioEditorWindow.Instance.OnNoiseVolumeChanged();
            AudioEditorWindow.Instance.Redraw();
        }*/
    }
}
