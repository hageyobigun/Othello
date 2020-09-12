using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerPutStone playerPutStone;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new PlayerInput();
        playerPutStone = GetComponent<PlayerPutStone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.IsPut())
        {
            playerPutStone.PutStone();
        }
    }
}
