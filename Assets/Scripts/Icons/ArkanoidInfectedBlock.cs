using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArkanoidInfectedBlock : MonoBehaviour
{
    [SerializeField] TextMeshPro _text;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;
    File _hiddenFile;

    public File HiddenFile { get { return _hiddenFile; } }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            _animator.enabled = false;
            Arkanoid arkanoid = collision.gameObject.GetComponentInParent<Arkanoid>();
            if (_hiddenFile)
            {
                _text.text = _hiddenFile.name;
                _spriteRenderer.sprite = _hiddenFile.Display.GetComponent<FileDisplay>().Sprite;
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
                Destroy(gameObject);
            arkanoid.BlockDestroyed();
        }
    }
    public void SetHiddenFile(File file)
    {
        _hiddenFile = file;
    }
}
