using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameComponent
{
    [SerializeField] DogController dog = null;
    [SerializeField] AudioSource whistle = null;


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

        if (other.gameObject.tag == "Distract")
        {
            ItemController item = other.gameObject.GetComponent<ItemController>();
         //   item.highlight();
            Debug.Log("PlayerController near to Distract");
          //  if (item == getGameController().getCurrentItem())
            {
            //    item.gameObject.active = false;
               // getGameController().gotoNextItem();
            }
            // other.gameObject.GetComponent<DogController>().nextClue(thisItemType, nextClueType);
        }
    }


    public void Action1()
    {
        Debug.Log("Whistle!");
        dog.hearWhistle();
        //   getGameController().getdog
        whistle.Play();
    }

    public void Action2()
    {
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
