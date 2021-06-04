using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;                              //Вводим переменную текстуры
    public float speed;                          //Вводим переменную скорости
    public float jumpHeight;
    public Transform groundCheck; // Вводим для проверки земля-воздух
    bool isGrounded;              // Вводим для проверки земля-воздух
    Animator anim;
    public int currHp;
    int maxHp = 3;
    bool isHit = false;   // Проверка на удар
    public Main main;

    public int Coins = 0;

    public Soundeffector soundeffector;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        //Создаем отсылку на текстуру игрока
        anim = GetComponent<Animator>();
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>();
        soundeffector = main.gameObject.GetComponent<Soundeffector>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        currHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        CheckGround();
       

        if (joystick.Horizontal == 0f && (isGrounded))
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            

            if (isGrounded)
                anim.SetInteger("State", 2);
        }
        if (transform.position.y < -10)
        {
            Invoke("Lose", 1f);
        }

        if (joystick.Horizontal >= 0f || joystick.Horizontal <= 0f)
        {
            Flip();
        }

       

    }
    void FixedUpdate()                           //Вводим метод физического движка
    {
        if (joystick.Horizontal >= 0.2f)
        rb.velocity = new Vector2(speed, rb.velocity.y);   //Задаем направление движения персонажа ( по горизонтали )
        else if (joystick.Horizontal <= -0.2f)
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }
    void Flip() //Вводим поворот персонажа при смене направления
    {
        if (joystick.Horizontal > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (joystick.Horizontal < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    void CheckGround()  // Проверка на положение
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
    }
    public void RecountHp(int deltaHp)
    {
        if (isHit) return;

        currHp = currHp + deltaHp;  // Прописываем изменение хп
        if (deltaHp < 0)
        {
            StopCoroutine(OnHit());
            isHit = true;
            StartCoroutine(OnHit());
        }

        if (currHp <= 0)
        {
            GetComponent<CapsuleCollider2D>().enabled = false; // Действие после смерти
            Invoke("Lose", 2f); // 2f это время через которое сработает метод Lose ( Конец сцены )
        }
    }
    IEnumerator OnHit()
    {
        if (isHit)
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f, GetComponent<SpriteRenderer>().color.a - 0.04f);
        else
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f, GetComponent<SpriteRenderer>().color.a + 0.04f);
        if (GetComponent<SpriteRenderer>().color.a == 1f)
            StopCoroutine(OnHit());
   
        if (GetComponent<SpriteRenderer>().color.a <= 0)
            isHit = false;
        yield return new WaitForSeconds(0.04f);
        StartCoroutine(OnHit());
    }
    void Lose()
    {
        main.GetComponent<Main>().Lose(); // Создаем метод Lose
    }

    private void OnCollisionEnter2D(Collision2D collision)        //ввели, чтобы игрок двигался вместе с платформой, а не подпрыгивал на ней при перемещении
    {
        if (collision.gameObject.tag.Equals ("Lift"))
        {
            this.transform.parent = collision.transform;
        }  

    }

    private void OnCollisionExit2D(Collision2D collision)        //ввели, чтобы игрок двигался вместе с платформой, а не подпрыгивал на ней при перемещении
    {
        if (collision.gameObject.tag.Equals("Lift"))
        {
            this.transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            Coins++;
            soundeffector.PlayCoinSound();
        }

        
    }

    public void OnMouseDown()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            soundeffector.PlayJumpSound();
        }
    }

    public int GetCoins()
    {
        return Coins;
    }
}

