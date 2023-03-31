using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour    
{
    [SerializeField] private short endsOnLvl;
    public short getEndsOnLvl()    { return endsOnLvl; }    
}
