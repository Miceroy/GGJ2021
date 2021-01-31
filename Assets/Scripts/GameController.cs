using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    [SerializeField] AudioSource wrongSound = null;
    [SerializeField] AudioSource pickSound = null;
    private bool stoppedGame = false;
    [SerializeField] Text totalTimeText = null;
    [SerializeField] Text resultText = null;
    [SerializeField] ItemController[] m_itemsList;
    [SerializeField] ItemController[] m_distractItemsList;
    int curIndex = -1;
    
    List<GameComponent> m_components = new List<GameComponent>();
    List<ItemController> m_items = new List<ItemController>();
    List<PlayerController> m_players= new List<PlayerController>();
    List<DuckCtrl> m_ducks = new List<DuckCtrl>();

    public float time = 0.0f;

    public int getItemsTotal()
    {
        return m_itemsList.Length;
    }


    public int getItemsLeft()
    {
        return m_itemsList.Length-curIndex;
    }
    public ItemController[] getDistractItems()
    {
        return m_distractItemsList;
    }

    private void Start()
    {
        resultText.text = "";
        time = 0;
        gotoNextItem();
    }

    public void gotoNextItem()
    {
        if (curIndex >= 0)
        {
            pickSound.Play();
        }
        curIndex++;
    }

    /*public void gotoPrevItem()
    {
        if (curIndex >= 0)
        {
        //    pickSound.Play();
        }
        curIndex--;
    }*/

    public void playWrongSound()
    {
        if (!wrongSound.isPlaying)
        {
            wrongSound.Play();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public ItemController getCurrentItem()
    {
        if (curIndex >= 0 && curIndex < m_itemsList.Length)
        {
            return m_itemsList[curIndex];

        }
        return null;
    }

    void Update()
    {
        if (!stoppedGame)
        {
            time += Time.deltaTime;
            totalTimeText.text = "Time: " + time.ToString(".00");
        }
        /*else
        {*/
        if (curIndex >= m_itemsList.Length)
        {
            // End game
            stoppedGame = true;
            Invoke("EndGame", 3.0f);
            resultText.text = "Result time: " + time.ToString(".00");
        }
    }
        /*}
    }*/

    public void registerComponent(GameComponent newComponent)
    {
        m_components.Add(newComponent);
        if(newComponent.GetType() == typeof(ItemController))
        {
            m_items.Add((ItemController)newComponent);
            Debug.Log("# Items: " + m_items.Count);
        }
        if (newComponent.GetType() == typeof(PlayerController))
        {
            m_players.Add((PlayerController)newComponent);
            Debug.Log("# Players: " + m_players.Count);
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
            Debug.Log("No given items found from level: " + type.ToString());
            return null;
        }

        return foundItems[0];
    }

    public PlayerController getPlayer()
    {
        if (m_players.Count > 1)
        {
            Debug.LogAssertion("Found many players found");
        }
        else if (m_players.Count < 1)
        {
            Debug.LogAssertion("No players found");
        }
        return m_players[0];
    }

    // Start is called before the first frame update
    /*  void Start() {
      }
  */
    // Update is called once per frame
    // void Update() {
        // Debug.Log("Num Objects: " + m_components.Count);
    // }
}
