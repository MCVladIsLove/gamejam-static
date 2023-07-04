using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderInfectedDisplay : FileDisplay
{
    [SerializeField] Animator _animator;
    [SerializeField] Sprite _curedSprite;

    protected override void Awake()
    {
        base.Awake();
        Noise.StartNoise(0.3f, 1, 0.7f, true);
    }
    protected override void OnMouseEnter()
    {
        base.OnMouseEnter();
        FolderInfected folder = (FolderInfected)_file;
        if (folder.Infected)
            Noise.StartNoise(0.3f, 1, 0.15f, true);
    }
    protected override void OnMouseUpAsButton()
    {
        FolderInfected folder = (FolderInfected)_file;
        if (folder.FileOpenedDisplay.TryGetComponent<Arkanoid>(out Arkanoid arkanoid) && Arkanoid.Playing)
            return;
        base.OnMouseUpAsButton();
        if (folder.Infected)
            Noise.StartNoise(0.3f, 5, 0.3f, true);
    }
    public override void Open()
    {        
        base.Open();
    }

    public override void Redraw()
    {
        base.Redraw();
        FolderInfected folder = (FolderInfected)_file;
        if (folder.Infected == false)
        {
            _animator.enabled = false;
            _spriteRenderer.sprite = _curedSprite;
        }
    }

}
