using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arkanoid : FolderWindow
{
    [SerializeField] ArkanoidInfectedBlock _infectedBlock;
    [SerializeField] int _blocks;
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _platform;
    [SerializeField] float _speed;
    [SerializeField] float _ballSpeed;
    [SerializeField] Sprite _secretSprite;
    Rigidbody2D _ballRb;
    static public bool Playing = false;
    public override File OriginaFile => _originalFile;

    protected override void Awake()
    {
        Playing = true;
        StartCoroutine(StartGame());
        base.Awake();
    }


    public override void Show(File file)
    {
        ArkanoidInfectedBlock createdBlock;
        _text.text = "??S/????S/s/?**xx";
        int i = 0;
        foreach (File f in _originalFile.GetChildren())
        {
            createdBlock = Instantiate(_infectedBlock);
            createdBlock.SetHiddenFile(f);
            _grid.FillCell(i++, createdBlock.gameObject);
            //createdFile.SetFilePath(_text.text + f.name);
        }
        for (; i < _blocks; i++)
        {
            createdBlock = Instantiate(_infectedBlock);
            _grid.FillCell(i, createdBlock.gameObject);
        }
        for (; i < _grid.Capacity; i++)
            _grid.GetCell(i).IsOccupied = true;
    }
    private void Update()
    {
        _platform.transform.Translate(Vector3.right * Time.deltaTime * _speed * Input.GetAxis("Horizontal"));
    }
    private void FixedUpdate()
    {
        if (_ballRb != null)
           _ballRb.velocity = _ballRb.velocity.normalized * _ballSpeed;
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        _ballRb = _ball.GetComponent<Rigidbody2D>();
        _ballRb.velocity = new Vector2(Random.Range(-1, 1), Random.Range(0.3f, 1)) * 3;
    }

    public void BlockDestroyed()
    {
        _blocks--;
        if (Random.value >= 0.9)
        {
            _ball.transform.localScale = Vector3.one * 0.3104244f;
            _ball.GetComponent<CircleCollider2D>().radius = 1.5f;
            _ball.GetComponent<SpriteRenderer>().sprite = _secretSprite;
        }
        if (_blocks == 0)
            Win();
    }
    void Win()
    {
        FolderInfected folder = (FolderInfected)_originalFile;
        folder.Cure();
        DisplayManager.Instance.OpenFile(_originalFile, this);
    }
    public void Lose()
    {
        File parent = OriginaFile.GetParent();
        if (parent != null)
            DisplayManager.Instance.OpenFile(parent, GetComponentInParent<Window>());
        else
            DisplayManager.Instance.CloseWindow(gameObject);

        Noise.StartNoise(0.3f, 3, 0.4f, true);
    }
    private void OnDestroy()
    {
        Playing = false;
    }
    public override void Redraw()
    {
    }
}