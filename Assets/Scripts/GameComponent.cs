using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public GameController getGameController()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("GameController");
        if (gos.Length == 1)
        {
            GameController ctrl = gos[0].GetComponent<GameController>();
            if (ctrl == null)
            {
                Debug.LogAssertion("No GameController component in GameController.");
            }
            return ctrl;
        }
        else if (gos.Length > 1)
        {
            Debug.LogAssertion("Too many GameControllers in the scene.");
        }
        else
        {
            Debug.LogAssertion("No GameControllers found from scene.");
        }
        return null;
    }

    public void OnEnable()
    {
        getGameController().registerComponent(this);
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
    }
}
