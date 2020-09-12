using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPutStone : MonoBehaviour
{
    [SerializeField] private Camera myCamera = null;
    [SerializeField] private GameObject stone = null;
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物

    //タップで石を置く処理
    public void PutStone()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast(ray, out hit))  
        {
            var cloneStone = Instantiate(stone, hit.transform.position, Quaternion.identity);
            cloneStone.transform.position += new Vector3(0, 0.5f, 0);
        }
    }
}
