using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<GameComponent> m_components;

    public void registerComponent(GameComponent newComponent)
    {
        Debug.LogAssertion("Comp registered");
        m_components.Add(newComponent);
    }

    public void unregisterComponent(GameComponent newComponent)
    {
        m_components.Remove(newComponent);
    }

    // Start is called before the first frame update
  /*  void Start() {
    }

    // Update is called once per frame
    void Update() {
    }*/
}
