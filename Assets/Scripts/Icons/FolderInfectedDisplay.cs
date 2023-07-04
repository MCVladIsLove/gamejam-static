using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderInfectedDisplay : FileDisplay
{
    [SerializeField] Animator _animator;
    [SerializeField] Sprite _curedSprite;

    protected override void OnMouseUpAsButton()
    {
        FolderInfected folder = (FolderInfected)_file;
        if (folder.FileOpenedDisplay.TryGetComponent<Arkanoid>(out Arkanoid arkanoid) && Arkanoid.Playing)
            return;
        base.OnMouseUpAsButton();
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
