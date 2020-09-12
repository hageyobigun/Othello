using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    [SerializeField] private GameObject boardBlock;
    [SerializeField] private GameObject boardWhiteBlock;
    [SerializeField] private Transform parentBoard;

    // Start is called before the first frame update
    void Awake()
    {
        BoardGenerator();
    }

    private void BoardGenerator()
    {
        for(var x = 0; x < 8; x++)
        {
            for(var z = 0; z < 8; z++)
            {
                var cloneBoardBlock = Instantiate(boardBlock, new Vector3(x, 0, z), Quaternion.identity);
                cloneBoardBlock.transform.parent = parentBoard;
                chengeBlock();
            }
            chengeBlock();
        }
    }

    private void chengeBlock()
    {
        var chengeBlock = boardBlock;
        boardBlock = boardWhiteBlock;
        boardWhiteBlock = chengeBlock;
    }
}
