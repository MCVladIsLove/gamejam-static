using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
            GetComponentInParent<Arkanoid>().Lose();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Plate")
            SoundManager.Instance.Play(SoundManager.Instance.ArkanoidPlateHit);

    }
}
