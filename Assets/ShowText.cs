using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : GameComponent
{
    public Text text = null;

    // Update is called once per frame
    void Update()
    {
        text.text = "" + getGameController().getItemsLeft() + "/" + getGameController().getItemsTotal();
    }
}
