using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public void OnEnable()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("GameController");
        if(gos.Length == 1)
        {
            GameController ctrl = gos[0].GetComponent<GameController>();
            if( ctrl != null )
            {
                ctrl.registerComponent(this);
            }
        }
        else if(gos.Length > 1)
        {
            Debug.LogAssertion("Too many GameControllers in the scene.");
        }
        else
        {
            Debug.LogAssertion("No GameControllers found from scene.");
        }
    }

    public void OnDestroy()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("GameController");
        if (gos.Length == 1)
        {
            GameController ctrl = gos[0].GetComponent<GameController>();
            if (ctrl != null)
            {
                ctrl.unregisterComponent(this);
            }
        }
        else if (gos.Length > 1)
        {
            Debug.LogAssertion("Too many GameControllers in the scene.");
        }
        else
        {
            Debug.LogAssertion("No GameControllers found from scene.");
        }
    }

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
