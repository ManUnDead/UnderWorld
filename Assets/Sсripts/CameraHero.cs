    using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraHero : MonoBehaviour
{
   
    float speed = 4f;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    transform.position = new Vector3(target.transform.position.x, target.transform.position.y , transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = target.position;
        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
