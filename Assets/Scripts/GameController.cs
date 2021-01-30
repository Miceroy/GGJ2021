using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<GameComponent> m_components = new List<GameComponent>();
    List<ItemController> m_items = new List<ItemController>();

    public void registerComponent(GameComponent newComponent)
    {
        m_components.Add(newComponent);
        if(newComponent.GetType() == typeof(ItemController))
        {
            m_items.Add((ItemController)newComponent);
            Debug.Log("# Items: " + m_items.Count);
        }
    }

    public void unregisterComponent(GameComponent newComponent)
    {
        m_components.Remove(newComponent);
    }

    public ItemController getItemOfType(ItemType type)
    {
        if(type == ItemType.NONE)
        {
            return null;
        }

        List<ItemController> foundItems = new List<ItemController>();
        for ( int i =0; i<m_items.Count; ++i)
        {
            if(type == m_items[i].getItemType())
            {
                foundItems.Add(m_items[i]);
            }
        }

        if( foundItems.Count > 1 )
        {
            Debug.LogAssertion("Found many items of similar kind: " + type.ToString());
        }
        else if (foundItems.Count < 1)
        {
            Debug.LogAssertion("No given items found from level: " + type.ToString());
        }

        return foundItems[0];
    }

    // Start is called before the first frame update
  /*  void Start() {
    }
*/
    // Update is called once per frame
   /* void Update() {
       // Debug.Log("Num Objects: " + m_components.Count);
    }*/
}
