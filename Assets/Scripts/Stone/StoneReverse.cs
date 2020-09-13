using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneReverse
{
    public void Reverse(int reverse_x, int reverse_z, Vector3 putPos, int playerID)
    {
        putPos = putPos + new Vector3(reverse_x, 0, reverse_z);
        if (playerID == 1) //playerは白
        {
            if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.Black)
            {
                StageManager.Instance.boardStone[(int)putPos.x, (int)putPos.z].transform.Rotate(180, 0, 0);
                StageManager.Instance.board[(int)putPos.x, (int)putPos.z] = StageManager.STONE_TYPE.White;
                Reverse(reverse_x, reverse_z, putPos, playerID);
            }
            else if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.White) //挟んでる
            {
                return;
            }
        }
        else if (playerID == 2)//playerは黒
        {
            if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.White)
            {
                StageManager.Instance.boardStone[(int)putPos.x, (int)putPos.z].transform.Rotate(180, 0, 0);
                StageManager.Instance.board[(int)putPos.x, (int)putPos.z] = StageManager.STONE_TYPE.Black;
                Reverse(reverse_x, reverse_z, putPos, playerID);
            }
            else if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.Black) //挟んでる
            {
                return;
            }
        }
    }
}
