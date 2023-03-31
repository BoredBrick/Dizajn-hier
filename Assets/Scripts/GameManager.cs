using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 lastPosition;
    private void Start() { lastPosition = new Vector3(0, 0, 0); }

    public Vector3 getLastPosition() { return lastPosition; }
    public void setLastPosition(Vector3 lastPosition)
    {
        this.lastPosition = lastPosition;
    }
}
