using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : GameComponent
{
    PlayerController player;
    NavMeshAgent agent;

    ItemType nextClueType = ItemType.NONE;
    ItemController distractedItem = null;
    PlayerController retunrToPlayer = null;

    public void hearWhistle()
    {
        distractedItem = null;
        retunrToPlayer = player;
        agent.SetDestination(retunrToPlayer.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      //  navigateToClue(ItemType.SHUE);
        player = getGameController().getPlayer();
        
    }

    private void Update()
    {
        if (distractedItem)
        {
            Vector3 thisPos = transform.position;
            Vector3 navPos = distractedItem.transform.position;
            float mag = (thisPos - navPos).magnitude;

            if (mag < 2.0f)
            {
                agent.SetDestination(thisPos);
                if (!distractedItem.gameObject.activeSelf)
                {
                    distractedItem = null;
                }
            }
            else
            {
                //    agent.SetDestination(navPos);
            }

        }
        else if (retunrToPlayer)
        {
            Vector3 thisPos = transform.position;
            Vector3 navPos = retunrToPlayer.transform.position;
            float mag = (thisPos - navPos).magnitude;
            if (mag < 2.0f)
            {
                retunrToPlayer = null;
            }
            else
            {
                agent.SetDestination(navPos);
            }
        }
        else if (getGameController().getCurrentItem())
        {
            Vector3 thisPos = transform.position;
            Vector3 navPos = getGameController().getCurrentItem().transform.position;
            float mag = (thisPos - navPos).magnitude;
            if (mag < 2.0f)
            {
                // Debug.Log("StopAgent!");
                agent.SetDestination(thisPos);
            }
            else
            {
                agent.SetDestination(navPos);
            }
        }

        ItemController[] distract = getGameController().getDistractItems();
        for( int i=0; i<distract.Length; ++i)
        {
            Vector3 thisPos = transform.position;
            Vector3 otherPos = distract[i].transform.position;
            if(distract[i].distracting && (thisPos-otherPos).magnitude < 10)
            {
               // Debug.Log("Dog distract");
                distract[i].distracting = false;
                distractedItem = distract[i];
                Vector3 navPos = distract[i].transform.position;
                agent.SetDestination(navPos);
            }
        }
    }
    /*
    void navigateToClue(ItemType clue)
    {
        if (clue == ItemType.NONE)
        {
            Debug.Log("Next clue not set. Dog is going to Idle state.");
            nextClueType = clue;
        }
        else
        {
           // ItemController item = getGameController().getItemOfType(clue);
           // agent.SetDestination(item.gameObject.transform.position);
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
    */
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
