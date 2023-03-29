using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformOneTouch : MonoBehaviour
{
    short rnd;
    private void Start()
    {
        rnd = (short)Random.Range(0, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Thread.Sleep(500);
        if (rnd < 4)
            gameObject.SetActive(false);
    }
}
