using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    public enum STONE_TYPE
    {
        Normal,
        White,
        Black
    }

    public STONE_TYPE[,] board = new STONE_TYPE[8,8];
    public GameObject[,] boardStone = new GameObject[8, 8];
    public StoneCheck stoneCheck;
    public StoneReverse stoneReverse;
    
    [SerializeField] private GameObject stone = null;

    void Awake()
    {
        startStone();
        stoneCheck = new StoneCheck();
        stoneReverse = new StoneReverse();
    }


    public void startStone()
    {
        boardStone[3, 3] = Instantiate(stone, new Vector3(3, 0.5f, 3), Quaternion.identity);
        boardStone[4, 4] = Instantiate(stone, new Vector3(4, 0.5f, 4), Quaternion.identity);
        board[3, 3] = STONE_TYPE.White;
        board[4, 4] = STONE_TYPE.White;

        boardStone[3, 4] = Instantiate(stone, new Vector3(3, 0.5f, 4), new Quaternion(180f, 0f, 0f, 1.0f));
        boardStone[4, 3] = Instantiate(stone, new Vector3(4, 0.5f, 3), new Quaternion(180f, 0f, 0f, 1.0f));
        board[3, 4] = STONE_TYPE.Black;
        board[4, 3] = STONE_TYPE.Black;
    }

    public STONE_TYPE CheckStoneType(Vector3 putPos)
    {
        int checkPos_x = (int)putPos.x;
        int checkPos_z = (int)putPos.z;
        return (board[checkPos_x, checkPos_z]);
    }
}


