using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHp : MonoBehaviour  //Скрипт изменения хп, привязан к камере
{
    private Player playerScript;
    private float currhp;
    public GameObject[] prefHearts;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currhp = playerScript.currHp;
        if (currhp > 2)
        {
            prefHearts[0].SetActive(true);
            prefHearts[1].SetActive(true);
            prefHearts[2].SetActive(true);
        }
         else if (currhp > 1 && currhp <3)
        {
            prefHearts[2].SetActive(false); 
        }
        else if (currhp > 0 && currhp < 2)
        {
            prefHearts[1].SetActive(false);
        }
        if (currhp < 1)
        {
            prefHearts[0].SetActive(false);
        }
    }


}

