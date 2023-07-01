using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderBlockedDisplay : FileDisplay
{
    [SerializeField] ConfirmPassword _passwordField;
    [SerializeField] Sprite _unlockedSprite;
    protected override void Awake()
    {
    }

    public override void Open()
    {
        FolderBlocked folder = (FolderBlocked)_file;
        if (!folder.Blocked)
            base.Open();
    }

    protected override void OnMouseEnter()
    {
        FolderBlocked folder = (FolderBlocked)_file;
        if (folder.Blocked)
            _passwordField.gameObject.SetActive(true);
        else
            base.OnMouseEnter();
    }
    protected override void OnMouseExit()
    {
        FolderBlocked folder = (FolderBlocked)_file;
        if (folder.Blocked)
            _passwordField.gameObject.SetActive(false);
        else
            base.OnMouseExit();
    }

    protected override void OnMouseUpAsButton()
    {
        FolderBlocked folder = (FolderBlocked)_file;
        if (folder.Blocked)
        {
            if (folder.CheckPassword(_passwordField.Text))
            {
                folder.Unlock();
                _passwordField.gameObject.SetActive(false);
                base.OnMouseUpAsButton();
            }
            else
                _passwordField.Clear();
        }
        else
            base.OnMouseUpAsButton();
    }

    public override void SetAssociatedFile(File file)
    {
        base.SetAssociatedFile(file);
        FolderBlocked folder = (FolderBlocked)_file;
        if (folder.Blocked == false)
            _spriteRenderer.sprite = _unlockedSprite;
    }
}
