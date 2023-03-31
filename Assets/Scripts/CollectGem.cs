using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGem : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            /*
             * PlayerAddGem
             */
            collision.gameObject.SetActive(false);
        }            
    }
}
