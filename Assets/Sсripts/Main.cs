﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public Player player;

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
    }


    public void Win()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        WinScreen.SetActive(true);


        if (!PlayerPrefs.HasKey("Lvl") || PlayerPrefs.GetInt("Lvl") < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt("Lvl", SceneManager.GetActiveScene().buildIndex);
        print(PlayerPrefs.GetInt("Lvl"));
    }

    public void WinOf()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        WinScreen.SetActive(false);
    }

  
    }
