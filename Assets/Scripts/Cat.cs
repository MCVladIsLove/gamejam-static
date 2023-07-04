using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] GameObject _pupilLeft;
    [SerializeField] GameObject _pupilRight;
    [SerializeField] GameObject _closedLeft;
    [SerializeField] GameObject _closedRight;
    float _maxLeftDistance;
    float _maxRightDistance;
    [SerializeField] float _radius;
    bool _morseShown;
    void Start()
    {
        Vector2 leftBottomWorld = MainCamera.cam.ScreenToWorldPoint(Vector2.zero);
        _maxLeftDistance = Vector2.Distance(leftBottomWorld, _pupilLeft.transform.position);
        _maxRightDistance = Vector2.Distance(leftBottomWorld, _pupilRight.transform.position);
        Noise.Instance.ChangeScaryNoise();
    }

    void Update()
    {
        Vector3 mousePos = MainCamera.cam.ScreenToWorldPoint(Input.mousePosition);
        _pupilLeft.transform.localPosition = Vector2.Distance(_pupilLeft.transform.parent.position, mousePos) / _maxLeftDistance * _radius * (mousePos - _pupilLeft.transform.parent.position).normalized;
        _pupilRight.transform.localPosition = Vector2.Distance(_pupilRight.transform.parent.position, mousePos) / _maxRightDistance * _radius * (mousePos - _pupilRight.transform.parent.position).normalized;
    }

    void CloseEyes()
    {
        _pupilLeft.SetActive(false);
        _pupilRight.SetActive(false);
        _closedLeft.SetActive(true);
        _closedRight.SetActive(true);
    }
    void OpenEyes()
    {
        _pupilLeft.SetActive(true);
        _pupilRight.SetActive(true);
        _closedLeft.SetActive(false);
        _closedRight.SetActive(false);
    }
    IEnumerator MorseStart() // code 9837
    {
        _morseShown = true;
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(2f);

        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(2f);

        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(2f);

        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(1.2f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(0.1f);
        CloseEyes();
        yield return new WaitForSeconds(0.4f);
        OpenEyes();
        yield return new WaitForSeconds(2f);

        _morseShown = false;
    }
    private void OnMouseUpAsButton()
    {
        if (!_morseShown)
            StartCoroutine(MorseStart());
    }
}
