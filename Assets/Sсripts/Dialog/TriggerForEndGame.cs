using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForEndGame : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    public void Start()
    {

        
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            dialogueManager.StartDialogue(dialogue);
        }
    }

}

