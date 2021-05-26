using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shoot;
    public float timeShoot;
    public float line;
    // Start is called before the first frame update
    void Start()
    {
        shoot.transform.position = new Vector3(transform.position.x+line , transform.position.y, transform.position.z);
        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(timeShoot);
        Instantiate(bullet,shoot.transform.position, transform.rotation);

        StartCoroutine(Shooting());
    }
}
