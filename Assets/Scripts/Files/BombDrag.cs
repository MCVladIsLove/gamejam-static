using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrag : FileDrag
{
    Animator _boomAnimator;
    float _timePassed;
    BombFile _bomb;
    protected override void Start()
    {
        base.Start();
        _bomb = (BombFile)_file;
    }
    protected override void OnMouseDown()
    {
        _timePassed = 0;
        _ghostFile = Instantiate(_sprite);
        _boomAnimator = _ghostFile.GetComponent<Animator>();
        _boomAnimator.enabled = true;
        _ghostFile.sortingOrder = DisplayManager.Instance.TopLayer+1;
        _ghostFile.sortingLayerName = "vfx";
         _pointInWindow = HelpFunctions.GetMousePosWorld(transform.position.z) - transform.position;
        _isCaptured = true;
    }

    protected override void Update()
    {
        if (_isCaptured)
        {
            _timePassed += Time.deltaTime;
            _mousePos = HelpFunctions.GetMousePosWorld(transform.position.z);
            _ghostFile.transform.position = _mousePos - _pointInWindow;
            if (_timePassed > _bomb.BoomDuration)
                Detonate();
        }
    }

    protected override void OnMouseUp()
    {
        if (_isCaptured)
            base.OnMouseUp();
    }

    void Detonate()
    {
        Collider2D collider = Physics2D.GetRayIntersection(MainCamera.cam.ScreenPointToRay(Input.mousePosition)).collider;
        if (collider.gameObject.TryGetComponent<FolderBoarderDisplay>(out FolderBoarderDisplay display))
        {
            FolderBoarder folder = (FolderBoarder)display.AssociatedFile;
            if (folder.Boarder)
            {
                folder.Unlock();
                display.SpriteRenderer.sprite = display.UnlockedSprite;
                FileSystemManager.Instance.DeleteFile(_file, true);
                DisplayManager.Instance.DetachFileAndRedrawWindow(_file);
                Destroy(gameObject);
            }
        }
            
        //Destroy(_ghostFile.gameObject, 0.2f);
        Destroy(_ghostFile.gameObject, 0.3f);
        _isCaptured = false;
        SoundManager.Instance.Play(SoundManager.Instance.BombBang);
    }

}
