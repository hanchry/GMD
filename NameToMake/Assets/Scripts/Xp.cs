using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class Xp : MonoBehaviour
{
    private Character character;
    void Start()
    {
        
    }
    
    public int Value
    {
        get => character.xp;
        set => character.xp = value;
    }
}
