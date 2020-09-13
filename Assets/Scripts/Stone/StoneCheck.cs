using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCheck
{
    public bool CheckCanPutStone(int playerID, Vector3 putPos)
    {
        bool CanPut = false;
        for(var pos_x = -1; pos_x < 2; pos_x++)
        {
            for(var pos_z = -1; pos_z < 2; pos_z++)
            {
                Vector3 checkPos = putPos + new Vector3(pos_x, 0, pos_z);
                if (checkPos.x > 7 || checkPos.z > 7 || checkPos.x < 0 || checkPos.z < 0) continue;
                if (playerID == 1) //playerは白
                {
                    if (StageManager.Instance.CheckStoneType(checkPos) == StageManager.STONE_TYPE.Black)
                    {
                        if(CheckLinePutStone(pos_x, pos_z, putPos, playerID))
                        {
                            StageManager.Instance.stoneReverse.Reverse(pos_x, pos_z, putPos, playerID);
                            CanPut = true;
                        }
                    }
                }
                else if (playerID == 2)//playerは黒
                {
                    if (StageManager.Instance.CheckStoneType(checkPos) == StageManager.STONE_TYPE.White)
                    {
                        if (CheckLinePutStone(pos_x, pos_z, putPos, playerID))
                        {
                            StageManager.Instance.stoneReverse.Reverse(pos_x, pos_z, putPos, playerID);
                            CanPut = true;
                        }
                    }
                }
            }
        }
        return (CanPut);
    }

    public bool CheckLinePutStone(int pos_x, int pos_z, Vector3 putPos, int playerID)
    {
        putPos = putPos + new Vector3(pos_x, 0, pos_z);
        bool isReverse = false;
        if (putPos.x > 7 || putPos.z > 7 || putPos.x < 0 || putPos.z < 0) return (false);
        if (playerID == 1) //playerは白
        {
            if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.Black)
            {
                isReverse = CheckLinePutStone(pos_x, pos_z, putPos, playerID);
            }
            else if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.White) //挟んでる
            {
                return (true);
            }
        }
        else if (playerID == 2)//playerは黒
        {
            if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.White)
            {
                isReverse = CheckLinePutStone(pos_x, pos_z, putPos, playerID);
            }
            else if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.Black) //挟んでる
            {
                return (true);
            }
        }
        if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.Normal)//アウト
        {
            return (false);
        }
        return (isReverse);
    }
}
