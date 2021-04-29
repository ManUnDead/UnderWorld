using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogyDance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300f, ForceMode2D.Impulse);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 100f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Jump());
    }
}
