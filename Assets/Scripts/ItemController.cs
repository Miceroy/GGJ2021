using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Pleaaja klikkaa kenkää -> koira haistaa sitä -> Koira menee sukan luo.
// Koira menny sukan luo -> Haistaa sukkaa -> Koira menee housujen luokse.
// Koira menee housun luokse -> Haistaa housua -> Koira menee ihmishahmon luokse.



public class ItemController : GameComponent
{
    [SerializeField] GameObject hightLightObject = null;

    [SerializeField] ItemType thisItemType = ItemType.NONE;
    [SerializeField] ItemType nextClueType = ItemType.NONE;

    public bool distracting = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
           // Debug.Log("Dog near to item");
           // other.gameObject.GetComponent<DogController>().nextClue(thisItemType, nextClueType);
        }
    }

    public ItemType getItemType()
    {
        return thisItemType;
    }

    private void Start()
    {
        if (hightLightObject == null)
        {
            Debug.LogAssertion("No highlight object defined for Item!");
        }
        hightLightObject.SetActive(false);
    }

    public void highlight()
    {
        if (!hightLightObject.activeSelf)
        {
            //Debug.Log("TODO: Item highlight");
            hightLightObject.SetActive(true);
        }
    }

    public void unHighlight()
    {
        if (hightLightObject.activeSelf)
        {
            //Debug.Log("TODO: Item unhighlight");
            hightLightObject.SetActive(false);
        }
    }
}
