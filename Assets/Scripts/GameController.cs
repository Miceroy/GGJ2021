using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    [SerializeField] float deltaFromDuck = 5.0f;
    [SerializeField] GameObject info = null;
    [SerializeField] AudioSource wrongSound = null;
    [SerializeField] AudioSource pickSound = null;
    public AudioClip[] AudioClipperino;
    private bool stoppedGame = false;
    [SerializeField] Text totalTimeText = null;
    [SerializeField] Text resultText = null;
    [SerializeField] ItemController[] m_itemsList;
    [SerializeField] ItemController[] m_distractItemsList;
    int curIndex = -1;
    public GameObject CorgiTextindicator1;
    public GameObject CorgiTextindicator2;
    public GameObject PlayerCamera;


    List<GameComponent> m_components = new List<GameComponent>();
    List<ItemController> m_items = new List<ItemController>();
    List<PlayerController> m_players= new List<PlayerController>();
    List<DuckCtrl> m_ducks = new List<DuckCtrl>();

    public float time = 0.0f;

    public void decreaseTime()
    {
        time -= 10.0f;
    }

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

        Cursor.lockState = CursorLockMode.Locked;
        resultText.text = "";
        time = 0;
        gotoNextItem();
    }

    public void gotoNextItem()
    {
        if (curIndex >= 0)
        {
            pickSound.Play();
            CorgiTextindicator2.SetActive(true);
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
            CorgiTextindicator1.SetActive(true);
        }
        else
        {
            StartCoroutine (Corgishutdown());
        }
    }
    IEnumerator Corgishutdown()
    {
        yield return new WaitForSeconds(3);
        CorgiTextindicator1.SetActive(false);
        CorgiTextindicator2.SetActive(false);
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
        if (time > deltaFromDuck)
        {
            info.SetActive(false);
        }

        if (!stoppedGame)
        {
            time += Time.deltaTime;
            totalTimeText.text = "Time: " + time.ToString(".0");
        }
        /*else
        {*/
        if (curIndex >= m_itemsList.Length)
        {
            // End game
            stoppedGame = true;
            Invoke("EndGame", 3.0f);
            resultText.text = "Result time: " + time.ToString(".0");
        }
    }

    void LateUpdate()
    {
        Vector3 v = PlayerCamera.transform.position - CorgiTextindicator1.transform.position;
        v.x = v.z = 0.0f;
        CorgiTextindicator1.transform.LookAt(PlayerCamera.transform.position - v);
        CorgiTextindicator1.transform.Rotate(0, 0, 0);

        Vector3 a = PlayerCamera.transform.position - CorgiTextindicator2.transform.position;
        a.x = a.z = 0.0f;
        CorgiTextindicator2.transform.LookAt(PlayerCamera.transform.position - a);
        CorgiTextindicator2.transform.Rotate(0, 0, 0);
    }

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
}
