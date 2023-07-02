using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderBoarderDisplay : FileDisplay
{
    [SerializeField] Sprite _unlockedSprite;

    public Sprite UnlockedSprite { get { return _unlockedSprite; } }
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } }
    public override void Open()
    {
        FolderBoarder folder = (FolderBoarder)_file;
        if (!folder.Boarder)
            base.Open();
    }

    protected override void OnMouseUpAsButton()
    {
        FolderBoarder folder = (FolderBoarder)_file;
        if (folder.Boarder)
        {
            // now nothing
        }
        else
            base.OnMouseUpAsButton();
    }

    public override void SetAssociatedFile(File file)
    {
        base.SetAssociatedFile(file);
        FolderBoarder folder = (FolderBoarder)_file;
        if (folder.Boarder == false)
            _spriteRenderer.sprite = _unlockedSprite;
    }
}
