using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTrigger2lvl : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    public void Start()
    {


        if (!PlayerPrefs.HasKey("Lvl2"))
        {
            PlayerPrefs.SetInt("Lvl2", SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            this.enabled = false;
        }
       




        FindObjectOfType<Main>().PauseOnDialogue();
        dialogueManager.StartDialogue(dialogue);
    }


}
