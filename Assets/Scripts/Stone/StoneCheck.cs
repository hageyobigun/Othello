using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCheck
{

    public void CheckCanPutStone()
    {
        for(var x = -1; x < 2; x++)
        {
            for(var z = -1; z < 2; z++)
            {
                StageManager.Instance.board[x, z] = 1;
            }
        }
    }

    public void CheckLinePutStone()
    {

    }
}
