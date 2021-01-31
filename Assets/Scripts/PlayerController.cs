using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameComponent
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            ItemController item = other.gameObject.GetComponent<ItemController>();
            item.highlight();
            //Debug.Log("PlayerController near to item");
            if(item == getGameController().getCurrentItem())
            {
                item.gameObject.active = false;
                getGameController().gotoNextItem();
            }
            // other.gameObject.GetComponent<DogController>().nextClue(thisItemType, nextClueType);
        }
    }


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
