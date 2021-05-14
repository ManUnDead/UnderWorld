using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
     
    public void Start ()
    {
        dialogueManager.StartDialogue(dialogue);
        FindObjectOfType<Main>().PauseOnDialogue();
    }

    
}
