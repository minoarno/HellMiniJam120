using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wall : MonoBehaviour
{
    public List<GameObject> Walls = new();
    
    // Start is called before the first frame update
    void Start()
    {
        int activeID = Random.Range(0,Walls.Count);
        for (int i = 0; i < Walls.Count; i++)
        {
            Walls[i].SetActive(i == activeID);
        }
    }
}
