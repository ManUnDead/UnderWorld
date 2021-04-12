using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Main main;  // не забыть поставить "Is triger " для корректной работы

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other) //Для 2D - в нашем случае, это событие выполняться не будет.
    {
        if (other.gameObject.tag == "Player") //Проверяем тэг объекта. Убедись, что у Игрока есть тег Player
        {
            Invoke("Win", 0f); //Загружаем сцену
        }
    }
    void Win()
    { 
    main.GetComponent<Main>().Win();
    }
}