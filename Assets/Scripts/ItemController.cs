using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Pleaaja klikkaa kenkää -> koira haistaa sitä -> Koira menee sukan luo.
// Koira menny sukan luo -> Haistaa sukkaa -> Koira menee housujen luokse.
// Koira menee housun luokse -> Haistaa housua -> Koira menee ihmishahmon luokse.



public class ItemController : GameComponent
{
    bool hlState = false;
    [SerializeField] ItemType thisItemType = ItemType.NONE;
    [SerializeField] ItemType nextClueType = ItemType.NONE;

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

    public void highlight()
    {
        if (!hlState)
        {
            Debug.Log("TODO: Item highlight");
            //gameObject.transform.localScale.Set(1.5f, 1.5f, 1.5f);
            hlState = true;
        }
    }

    public void unHighlight()
    {
        if (hlState)
        {
            Debug.Log("TODO: Item unhighlight");
            //gameObject.transform.localScale.Set(1.0f, 1.0f, 1.0f);
            hlState = false;
        }
    }
}
