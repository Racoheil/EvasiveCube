using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsControll : MonoBehaviour
{
    public int selectedLevel=1;
    public Text NumberOflevel;
    public static bool isUnBlocked = false;
    public static ButtonsControll instance;
    //public void unBlocked() { isUnBlocked = true; }
    private void Awake()
    {
        instance = this;
    }
    public void Play()
    {
        Debug.Log("PLAY");
        if (selectedLevel == 1) SceneManager.LoadScene("Level1");
        else if (selectedLevel == 2) SceneManager.LoadScene("Level2");
    }
    public void GoToShop()
    {
        Debug.Log("go to shop");
        SceneManager.LoadScene("Shop");
    }
    public void SignUpIn()
    {
        Debug.Log("SIGN");
    }
    public void Settings()
    {
        Debug.Log("Settings");
        SceneManager.LoadScene("Settings");
    }
    public void Next()
    {
        Debug.Log("NExt");
        if (playerInfromation.isUnblocked!=true) { Debug.Log("BLOCKED"); }
        else if (playerInfromation.isUnblocked == true)
        {
            NumberOflevel.text = "2";
            selectedLevel = 2;
        }
     
    }
    public void Back()
    {
        Debug.Log("Back");
        NumberOflevel.text = "1";
        selectedLevel = 1;
    }
    public void NoSound()
    {
        Debug.Log("Sound off");
    }
    public void NoAds()
    {
        Debug.Log("No Ads");
    }
    public void Exit()
    {
        Debug.Log("Exit");
    }
    public void BackToMenu()
    {
        Debug.Log("Back to menu");
        SceneManager.LoadScene("MainMenu");

    }

}
