using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConsumable : MonoBehaviour
{
    [SerializeField]
    Mesh gem, heart, random, mesh = null;

    void Start()
    {
        mesh = GetComponent<Mesh>();
        int rnd = Random.Range(0, 100);
        if (rnd < 50)
            mesh = gem;
        else if (rnd > 50 && rnd < 75)
            mesh = heart;
        else if (rnd > 75)
            mesh = random;
    }
}
