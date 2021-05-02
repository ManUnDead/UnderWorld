using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bullet : MonoBehaviour
    
{
     float speed = 5f;
    public float TimeToDisable;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetDisabled());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(TimeToDisable);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(SetDisabled());

        
    }
}
