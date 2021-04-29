using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurbo : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject SpawnObject;
    public float TimeSpawn;
    void Start()
    {
        
    }


   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            Instantiate(SpawnObject, SpawnPos.position, Quaternion.identity);
    }
}
