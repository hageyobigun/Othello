using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinner
{

    private Text winnerText;

    public GameWinner(Text text)
    {
        winnerText = text;
    }

    public void WinnerJudgment(int white,int black)
    {
        if(white < black)
        {
            winnerText.text = "黒の勝ち";
        }
        else if (white > black)
        {
            winnerText.text = "白の勝ち";
        }
        else
        {
            winnerText.text = "引き分け";
        }
    }

}
