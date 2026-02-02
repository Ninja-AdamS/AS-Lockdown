using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class randItem : MonoBehaviour
{

    System.Random random = new System.Random();
    public GameObject randItems;
    int randomNumber;
    bool HaveItem;
    public GameObject Bandages;
    public GameObject EnergyDrink;
    public GameObject Money;
    public Transform hand;

    void Start()
    {
        randomNumber = random.Next(0, 100);
        
        if (randomNumber <= 25)
        {
            randItems = EnergyDrink;
            randItems = Instantiate(EnergyDrink, transform.position, transform.rotation);
            CreateChildObject();
        }
        else if (randomNumber >= 26 && randomNumber <= 60)
        {
            randItems = Bandages;
            randItems = Instantiate(Bandages, transform.position, transform.rotation);
            CreateChildObject();
        }
        else if (randomNumber >= 61 && randomNumber <= 100)
        {
            randItems = Money;
            randItems = Instantiate(Money, transform.position, transform.rotation);
            CreateChildObject();
        }

    }

    void CreateChildObject()
    {
        randItems.transform.SetParent(hand.transform);
    }

    public void SpawnItem()
    {
        randItems = Instantiate(randItems, transform.position, transform.rotation);
    }

    public void DestroyItem()
    {
        Destroy(randItems);
    }

}

