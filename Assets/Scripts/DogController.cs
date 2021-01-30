using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : GameComponent
{
    public Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "Player")
        {
            Debug.Log("Dog near to player");
        }
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        if( other.gameObject.transform.parent.tag == "Player" )
        {
            Debug.Log("Dog far from player");

        }
    }
}
