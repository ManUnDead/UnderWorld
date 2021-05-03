using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject SpawnObject;
    public float TimeSpawn;

    int GetMoney = 0;
    public GameObject money;
    public Transform moneyPos;

    void Start()
    {
     
    }

    void Update()
    {
     
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Instantiate(SpawnObject, SpawnPos.position, Quaternion.identity);
            GetMoney++;
            StartCoroutine(SpawnMoney());
        }

    }

    IEnumerator SpawnMoney()
    {
        if (GetMoney % 2 != 0)
        Instantiate(money, moneyPos.position, Quaternion.identity);   
        yield return new WaitForSeconds(1f);
        StopCoroutine(SpawnMoney());
    }
}
