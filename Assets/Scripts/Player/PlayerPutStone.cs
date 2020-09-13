using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPutStone : MonoBehaviour
{
    [SerializeField] private Camera myCamera = null;
    [SerializeField] private GameObject stone = null;
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物

    //タップで石を置く処理
    public bool PutStone(int playerID)
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast(ray, out hit))  
        {
            var putPos = hit.transform.position;
            if (StageManager.Instance.CheckStoneType(putPos) == StageManager.STONE_TYPE.Normal)
            {
                if (StageManager.Instance.stoneCheck.CheckCanPutStone(playerID, hit.transform.position))
                {
                    var cloneStone = Instantiate(stone, hit.transform.position, Quaternion.identity);
                    if(playerID == 1)
                    {
                        StageManager.Instance.board[(int)putPos.x, (int)putPos.z] = StageManager.STONE_TYPE.White;
                    }
                    else if (playerID == 2)
                    {
                        StageManager.Instance.board[(int)putPos.x, (int)putPos.z] = StageManager.STONE_TYPE.Black;
                        cloneStone.transform.Rotate(180, 0, 0); //黒
                    }
                    cloneStone.transform.position += new Vector3(0, 0.5f, 0);
                    StageManager.Instance.boardStone[(int)putPos.x, (int)putPos.z] = cloneStone;
                    return (true);
                }
            }
        }
        return (false);
    }
}
