using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject BuyButton, BuyButtonCat;
    int BuySkin, BuyCat;
    int coins;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BuySkin"))
        {
            BuySkin=2;
        }

        BuySkin = PlayerPrefs.GetInt("BuySkin", 1);
        BuyCat = PlayerPrefs.GetInt("BuyCat", 1);
        coins = PlayerPrefs.GetInt("Coins");


        if (PlayerPrefs.HasKey("BuyCat"))
        {
            BuyCat = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BuySkin ==1)   // для покупки 
        {
            BuyButton.SetActive(true);
        }

        else
        {
            BuyButton.SetActive(false);
        }

        if (BuyCat ==1)      // Для покупки лисы
        {
            BuyButtonCat.SetActive(true);
        }
        else
        {
            BuyButtonCat.SetActive(false);
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

    public void BuyCaty()
    {
        if (coins >= 250)
        {
            coins -= 250;
            PlayerPrefs.SetInt("Coins", coins);
            BuyCat = 2;
            PlayerPrefs.GetInt("BuyCat", BuyCat);
            PlayerPrefs.SetInt("BuyCat", BuyCat);
        }
    }
}
