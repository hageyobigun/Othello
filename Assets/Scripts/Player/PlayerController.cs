using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerPutStone playerPutStone;
    [SerializeField] private int playerID = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new PlayerInput();
        playerPutStone = GetComponent<PlayerPutStone>();
        GameManeger.Instance.turnTexts.ChangeTurnText(playerID);
        GameManeger.Instance.stoneCount.CountStones();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManeger.Instance.currentState == GameManeger.GAME_STATE.Playing)
        {
            if (playerInput.IsPut() && playerID == 1)
            {
                if (playerPutStone.PutStone(playerID))
                {
                    playerID = 2;
                    GameManeger.Instance.turnTexts.ChangeTurnText(playerID);
                    GameManeger.Instance.stoneCount.CountStones();
                }
            }
            else if (playerInput.IsPut() && playerID == 2)
            {
                if (playerPutStone.PutStone(playerID))
                {
                    playerID = 1;
                    GameManeger.Instance.turnTexts.ChangeTurnText(playerID);
                    GameManeger.Instance.stoneCount.CountStones();

                }
            }
        }
    }
}
