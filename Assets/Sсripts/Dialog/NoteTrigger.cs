using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public GameObject note;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D col)
    {
        animator.SetBool("IsOpen", true);
        dialogueManager.StartDialogue(dialogue);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        animator.SetBool("IsOpen", false);
    }

}
