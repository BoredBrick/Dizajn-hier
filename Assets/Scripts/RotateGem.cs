using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGem : MonoBehaviour
{
    [SerializeField] float speed = 20;
    Vector3 rotation;
    private void Start()
    {
        rotation = new Vector3(0, 10, 0);
    }
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);        
    }
}
