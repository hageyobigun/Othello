using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneCount
{
    private Text[] blockCountText;

    public StoneCount(Text[] texts)
    {
        blockCountText = texts;
    }

    public (int, int) CountStones()
    {
        var whiteStones = 0;
        var blackStones = 0;
        for (var x = 0; x < 8; x++)
        {
            for (var z = 0; z < 8; z++)
            {
                Vector3 checkPos = new Vector3(x, 0, z);
                if (StageManager.Instance.CheckStoneType(checkPos) == StageManager.STONE_TYPE.White) whiteStones++;
                if (StageManager.Instance.CheckStoneType(checkPos) == StageManager.STONE_TYPE.Black) blackStones++;
            }
        }
        if(blackStones + whiteStones == 64 && GameManeger.Instance.currentState == GameManeger.GAME_STATE.Playing)
        {
            //終了処理
            GameManeger.Instance.dispatch(GameManeger.GAME_STATE.End);
        }
        blockCountText[0].text = "白：" + whiteStones.ToString();
        blockCountText[1].text = "黒：" + blackStones.ToString();
        return (whiteStones, blackStones);
    }

}
