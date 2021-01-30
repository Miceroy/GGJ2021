using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameComponent
{
    public void Action1(ItemController item)
    {
        Debug.Log("TODO: Player Action1. Item: " + item.name);
    }

    public void Action2(ItemController item)
    {
        Debug.Log("TODO: Player Action2. Item: " + item.name);
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
