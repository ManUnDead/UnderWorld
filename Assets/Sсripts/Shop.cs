using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject BuyButton;
    int BuySkin;
    int coins;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BuySkin"))
        {
            BuySkin=2;
        }

        BuySkin = PlayerPrefs.GetInt("BuySkin", 1);
        coins = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        if (BuySkin ==1)
        {
            BuyButton.SetActive(true);
        }

        else
        {
            BuyButton.SetActive(false);
        }
    }
     public void BuySkins()
    {
        if (coins >= 50)
        {
            coins -= 50;
            PlayerPrefs.SetInt("Coins",coins);
            BuySkin = 2;
            PlayerPrefs.GetInt("BuySkin", BuySkin);
            PlayerPrefs.SetInt("BuySkin", BuySkin);
        }
    }
}
