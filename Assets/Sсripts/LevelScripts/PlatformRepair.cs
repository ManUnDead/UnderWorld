using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRepair : MonoBehaviour
{
    int Herotouch = 0;
    public Animator animator;

    void Start()
    {
        StartCoroutine(Cracked());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Herotouch = 1;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Herotouch = 0;
    }

    IEnumerator Cracked()
    {

        if (Herotouch == 1)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            animator.SetBool("IsBroken",true);
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            animator.SetBool("IsBroken", false);
        }
        yield return new WaitForSeconds(1.5f); ;
        StopCoroutine(Cracked());
        StartCoroutine(Cracked());
    }
}
