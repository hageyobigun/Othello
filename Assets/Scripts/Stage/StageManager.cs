using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    public int[,] board = new int[8,8];
    public GameObject[,] boardStone = new GameObject[8, 8];
    [SerializeField] private GameObject stone = null;

    void Awake()
    {
        startStone();
    }

    public void startStone()
    {
        boardStone[3, 3] = Instantiate(stone, new Vector3(3, 0.5f, 3), Quaternion.identity);
        boardStone[4, 4] = Instantiate(stone, new Vector3(4, 0.5f, 4), Quaternion.identity);

        boardStone[3, 4] = Instantiate(stone, new Vector3(3, 0.5f, 4), new Quaternion(180f, 0f, 0f, 1.0f));
        boardStone[4, 3] = Instantiate(stone, new Vector3(4, 0.5f, 3), new Quaternion(180f, 0f, 0f, 1.0f));

    }
}
