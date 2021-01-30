using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : GameComponent
{
    PlayerController player;
    NavMeshAgent agent;

    ItemType nextClueType = ItemType.NONE;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        navigateToClue(ItemType.SHUE);
        player = getGameController().getPlayer();
    }

    void navigateToClue(ItemType clue)
    {
        if (clue == ItemType.NONE)
        {
            Debug.Log("Next clue not set. Dog is going to Idle state.");
            nextClueType = clue;
        }
        else
        {
            ItemController item = getGameController().getItemOfType(clue);
            agent.SetDestination(item.gameObject.transform.position);
            nextClueType = clue;
            Debug.Log("Dog got new clue to find: " + clue.ToString() + " at position: " + item.gameObject.transform.position.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nextClueType == ItemType.NONE)
        {
            // Idle
        }
        else
        {
            // Navigating to clue
        }
    }

    public void nextClue(ItemType current, ItemType clue)
    {
        if(current == nextClueType)
        {
            navigateToClue(clue);
        }
        else
        {
            //Debug.Log("Colliding to wrong type clue. Ignoring.");
        }
    }

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.tag == "Player")
        {
            Debug.Log("Dog near to player");
        }
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.parent != null && other.gameObject.transform.parent.tag == "Player" )
        {
            Debug.Log("Dog far from player");

        }
    }
}
