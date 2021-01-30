using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameComponent
{
    DogController dog = null;

    public void Action1(ItemController item)
    {
        dog.action1(item);
    }

    public void Action2(ItemController item)
    {
        dog.action2(item);
    }

    private void Start()
    {
        dog = getGameController().getDog();
    }

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TASK_GIVER")
        {
            Debug.Log("Player near to taskgiver");
            other.GetComponent<TaskGiverController>().showText();
            //dog.
        }
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TASK_GIVER")
        {
            Debug.Log("Player far from taskgiver");
            other.GetComponent<TaskGiverController>().hideText();
        }
    }

}
