using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForJumpButton : MonoBehaviour
{
    private Player playerScript;


    public void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }


    public void ForJump()
    {
        playerScript.Jump();
    }

    
}
