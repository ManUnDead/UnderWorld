using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Button[] lvls;
    public Text coinText ,coinText1;
    public Slider musicSlider, soundSlider;
    public Text musicText, soundText;

    

    void Start()
    {
     

        if (PlayerPrefs.HasKey("Lvl"))
            for (int i = 0; i< lvls.Length; i++)
            {
                if (i <= PlayerPrefs.GetInt("Lvl"))
                    lvls[i].interactable = true;
                else
                    lvls[i].interactable = false;
            }
        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetInt("MusicVolume", 3);
        if (!PlayerPrefs.HasKey("SoundVolume"))
            PlayerPrefs.SetInt("SoundVolume", 2);

        musicSlider.value = PlayerPrefs.GetInt("MusicVolume");
        soundSlider.value = PlayerPrefs.GetInt("SoundVolume");
    }

 
    void Update()
    {
        PlayerPrefs.SetInt("MusicVolume", (int)musicSlider.value);
        PlayerPrefs.SetInt("SoundVolume", (int)soundSlider.value);

        musicText.text = musicSlider.value.ToString();
        soundText.text = soundSlider.value.ToString();

        if (PlayerPrefs.HasKey("Coins"))
        {
            coinText.text = PlayerPrefs.GetInt("Coins").ToString();
            coinText1.text = PlayerPrefs.GetInt("Coins").ToString();
        }
        else
        {
            coinText.text = "0";
            coinText1.text = "0";
        }
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void DelKeys()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Quite()
    {
        Application.Quit();
    }
   
    public void SetPlayer(int index)   // Для скинов
    {
        PlayerPrefs.SetInt("Player", index);
    }


    
}
