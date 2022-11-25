using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public int Health = 10;
    public float Speed = 5f;
    public int Damage = 5;
    public float RespawnTimer = 5f;
}
