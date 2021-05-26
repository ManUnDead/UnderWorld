using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject LoseScreen;
    public GameObject WinScreen;

    private Player player;
    public Transform playerPos;
    public GameObject[] players;

    public Text coinText;
    public GameObject music;
    public Soundeffector soundeffector;

    private void Start()
    {
    
    }


    public void Update()
    {
     coinText.text = player.GetCoins().ToString();
    }

    private void Awake()
    {
        player = Instantiate(players[PlayerPrefs.GetInt("Player")], playerPos.position, Quaternion.identity).GetComponent<Player>();
    }

    public void ReloadLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        player.enabled = true;

    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        PauseScreen.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        PauseScreen.SetActive(false);
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        LoseScreen.SetActive(true);
        music.gameObject.SetActive(false);
        soundeffector.PlayLoseSound();
    }

    public void MenuLvl()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        player.enabled = true;
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        player.enabled = true;
        Time.timeScale = 1f;

        
    }


    public void Win()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        WinScreen.SetActive(true);

        music.gameObject.SetActive(false);
        soundeffector.PlayWinSound();

        if (!PlayerPrefs.HasKey("Lvl") || PlayerPrefs.GetInt("Lvl") < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt("Lvl", SceneManager.GetActiveScene().buildIndex);
        print(PlayerPrefs.GetInt("Lvl"));

        if (PlayerPrefs.HasKey("Coins"))
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + player.GetCoins());
        else
            PlayerPrefs.SetInt("Coins", player.GetCoins());
        
    }

    public void WinOf()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        WinScreen.SetActive(false);
    }



    public void PauseOnDialogue()
    {
        player.enabled = false;
    }

    public void PauseOfDialogue()
    {
        player.enabled = true;
    }
}
