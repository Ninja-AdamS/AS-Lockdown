using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phealth : MonoBehaviour
{
    public int health;
    
    public void Damaged()
    {
        health -= 10;
    }

    void Start()
    {
        health = 20;
    }

    void Update()
    {
        
    }
}
