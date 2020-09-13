using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : SingletonMonoBehaviour<GameManeger>
{
    public enum GAME_STATE
    {
        Opening,
        Playing,
        End
    }

    public GAME_STATE currentState = GAME_STATE.Opening;
    private GameWinner gameWinner;
    public StoneCount stoneCount;
    public TurnText turnTexts;
    [SerializeField] private Text[] blockCountText = null;
    [SerializeField] private Text turnText = null;
    [SerializeField] private Text winnerText = null;
    [SerializeField] private Button StartButton = null;

    private void Awake()
    {
        gameWinner = new GameWinner(winnerText);
        stoneCount = new StoneCount(blockCountText);
        turnTexts = new TurnText(turnText);
    }

    // 状態による振り分け処理
    public void dispatch(GAME_STATE state)
    {
        GAME_STATE oldState = currentState;
        currentState = state;
        switch (state)
        {
            case GAME_STATE.Opening:
                GameOpening();
                break;
            case GAME_STATE.Playing:
                GameStart();
                break;
            case GAME_STATE.End:
                GameEnd();
                break;
        }
    }

    // オープニング処理
    public void GameOpening()
    {
        currentState = GAME_STATE.Playing;
        StartButton.gameObject.SetActive(false);
    }
    void GameStart()
    {
        //処理
    }

    void GameEnd()
    {
        //処理
        currentState = GAME_STATE.End;
        var (whiteCount, blockConnt) = stoneCount.CountStones();
        gameWinner.WinnerJudgment(whiteCount, blockConnt);
    }

}
