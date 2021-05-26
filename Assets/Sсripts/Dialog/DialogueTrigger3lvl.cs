using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger3lvl : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    public void Start()
    {

        FindObjectOfType<Main>().PauseOnDialogue();
        dialogueManager.StartDialogue(dialogue);
    }


}
