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
}
