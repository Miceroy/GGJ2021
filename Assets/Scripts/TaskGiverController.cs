using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGiverController : GameComponent
{
    [SerializeField] string text = "Find the ... with this...";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showText()
    {
        Debug.Log(text);
    }

    public void hideText()
    {
        
    }
}
