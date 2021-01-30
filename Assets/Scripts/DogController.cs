using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : GameComponent
{
    [SerializeField] float destinationReachDistance = 40.0f;

    enum State
    {
        STAY_NEAR,
        START_SNIFF,
        HUNTING_CLUE,
        HUNTING_DISTRACTED_CLUE,
      //  COMING_BACK_FROM_DISTRACTION,
        BARKING_TARGET,
        WATCHING_TARGET,
    };

    PlayerController player;
    NavMeshAgent agent;

    State m_state;

    ItemType realClueType = ItemType.NONE;
    ItemType distractClueType = ItemType.DISTRACT;
/*
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //navigateToClue(ItemType.SHUE);
        player = getGameController().getPlayer();
        m_state = State.IDLE;
    }

    // Haukkuu niin kauan, kuin pelaaja tulee vaikutusalueelle.

    void clueDistract()
    {
        m_state = HUNTING_DISTRACTED_CLUE;

    }
    */
    void navigateToClue(ItemType clue)
    {
        if (m_state == State.STAY_NEAR)
        {
            if (clue == ItemType.NONE)
            {
                Debug.Log("Next clue not set. Dog is going to Idle state.");
                m_state = State.STAY_NEAR;
            }
            else
            {
                ItemController item = getGameController().getItemOfType(clue);
                agent.SetDestination(item.gameObject.transform.position);
                realClueType = clue;
                m_state = State.HUNTING_CLUE;
                Debug.Log("Dog got new clue to find: " + clue.ToString() + " at position: " + item.gameObject.transform.position.ToString());
            }
        }
    }

    bool isNearDestination() {
        float dist = (agent.destination - transform.position).magnitude;
        Debug.Log("Dog distance to clue: " + dist.ToString());
        return dist < destinationReachDistance;
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_state)
        {
            case State.STAY_NEAR:
                // Wonder around player
                break;
            case State.HUNTING_DISTRACTED_CLUE:
                // Chase distracted clue
                break;
           // case State.COMING_BACK_FROM_DISTRACTION:
                // Vihellys, koira tulee minun luokse. Koira lähtee seuraamaan alkuperäistä jälkeä.
             //   break;
            case State.BARKING_TARGET:
                Debug.Log("Dog bark! Räyh räyh räyh!");
                break;
            case State.WATCHING_TARGET:
                Debug.Log("Dog watching target");
                break;
            case State.HUNTING_CLUE:
                if( isNearDestination() )
                {
                    Debug.Log("Dog reach destination to clue. Start barking!");
                    agent.isStopped = true;
                    m_state = State.BARKING_TARGET;
                }
                break;
        }


       // if (nextClueType == ItemType.NONE)
        {
            // Idle
        }
       // else
        {
            // Navigating to clue
        }
    }

   /* public void nextClue(ItemType current, ItemType clue)
    {
        if(current == nextClueType)
        {
            navigateToClue(clue);
        }
        else
        {
            //Debug.Log("Colliding to wrong type clue. Ignoring.");
        }
    }*/

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.tag == "Player")
        {
          //  Debug.Log("Dog near to player");
        }
        if ( other.gameObject.tag == "Dog")
        {
            Debug.Log("Dog near to item");
            if (m_state == State.HUNTING_CLUE)
            {
                // Goto Barking state.
                m_state = State.BARKING_TARGET;
                agent.isStopped = true;
            }
           // if (m_state == State.HUNTING_CLUE)
        }
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.parent != null && other.gameObject.transform.parent.tag == "Player" )
        {
        //    Debug.Log("Dog far from player");

        }
        if (other.gameObject.tag == "Dog")
        {
            Debug.Log("Dog far from item");
        }
    }

    public void navigateToDestination()
    {

    }

    public void action1(ItemController item)
    {
        Debug.Log("Dog start sniffing item: " + item.name);
        m_state = State.START_SNIFF;
        agent.SetDestination(item.transform.position);
    }

    public void action2(ItemController item)
    {
        Debug.Log("Dog start chasing item: " + item.name);
        navigateToClue(item.getNextItemType());
    }

    public void hearsWhistle()
    {
        Debug.Log("Dog goes back to palyer");
        m_state = State.STAY_NEAR;
        agent.SetDestination(player.transform.position);
    }

    public void watchTarget()
    {

    }
}
