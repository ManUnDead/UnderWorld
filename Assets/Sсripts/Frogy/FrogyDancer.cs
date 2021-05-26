using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class FrogyDancer : MonoBehaviour
{
    public bool moveLeft = true;
    public float speed = 1f;
    public Transform wallDetect;

    int currHp;
    public int maxHp = 10;
    [SerializeField] bool isHit = false;
    Animator anim;

    void Start()
    {
        currHp = maxHp;

        anim = GetComponent<Animator>();

        StartCoroutine(Jump());
    }

    void Update()   
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(wallDetect.position, Vector2.left, 1f);  // 1 наименование в скобках - тот объект от которого идет луч, 2 наименование  - куда идет луч, 3 длина луча.
        if (groundInfo.collider == true)
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
            }
        }
    }

    public void RecountHp(int deltaHp)
    {
        if (currHp <= 0)
        {
            gameObject.GetComponentInParent<Enemy>().startDeath();
        }


        if (isHit) return;

        currHp = currHp + deltaHp;  // Прописываем изменение хп
        if (deltaHp < 0)
        {
            StartCoroutine(OnHit());
        }

        
    }
    IEnumerator OnHit()
    {
        isHit = true;
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Hit", false);
        isHit = false;
    }

        IEnumerator Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300f, ForceMode2D.Impulse);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 100f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Jump());

    }

    private void ResetHit()
    {
      
        anim.ResetTrigger("Hit");
    }

}
