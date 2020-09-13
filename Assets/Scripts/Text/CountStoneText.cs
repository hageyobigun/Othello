using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountStoneText : MonoBehaviour
{
    private Text[] blockCountText;

    public CountStoneText(Text[] texts)
    {
        blockCountText = texts;
    }

    public void CountStones(int whiteStones, int blackStones)
    {
        blockCountText[0].text = "白：" + whiteStones.ToString();
        blockCountText[1].text = "黒：" + blackStones.ToString();
    }
}
