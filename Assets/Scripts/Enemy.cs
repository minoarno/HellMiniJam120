using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType EnemyType;
    public CharacterStats CharacterStats;

    public static Player Player = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Player == null) return;

        
        if (CharacterStats)
        {
            
        }
    }
}
