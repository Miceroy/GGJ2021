using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Pleaaja klikkaa kenkää -> koira haistaa sitä -> Koira menee sukan luo.
// Koira menny sukan luo -> Haistaa sukkaa -> Koira menee housujen luokse.
// Koira menee housun luokse -> Haistaa housua -> Koira menee ihmishahmon luokse.



public class ItemController : GameComponent
{
    [SerializeField] ItemType thisItemType;
    [SerializeField] ItemType nextClueType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
           // Debug.Log("Dog near to item");
            other.gameObject.GetComponent<DogController>().nextClue(thisItemType, nextClueType);
        }
    }

    public ItemType getItemType()
    {
        return thisItemType;
    }

    //When the Primitive exits the collision, it will change Color
   /* private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
            Debug.Log("Dog far from item");
        }
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
