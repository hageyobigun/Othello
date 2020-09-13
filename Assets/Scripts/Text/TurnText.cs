using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnText
{
    private Text turnText;
    public TurnText(Text text)
    {
        turnText = text;
    }

    public void ChangeTurnText(int playerID)
    {
        if (playerID == 1)
        {
            turnText.text = "白のターン";
            turnText.material.color = new Color(255, 255, 255);
        }
        if (playerID == 2)
        {
            turnText.text = "黒のターン";
            turnText.material.color = new Color(0, 0, 0);
        }
        if(GameManeger.Instance.currentState == GameManeger.GAME_STATE.End)
        {
            turnText.text = "";
        }
    }
}
