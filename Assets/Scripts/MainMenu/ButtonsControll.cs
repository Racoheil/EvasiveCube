using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsControll : MonoBehaviour
{
    public GameObject panel;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public int selectedLevel=1;
    
    public static bool isUnBlocked = false;
    public static ButtonsControll instance;
    public bool isSound;
    public TMP_Text NumberOfLevel;
    //public void unBlocked() { isUnBlocked = true; }
    public void pauseButtonHide()
    {
        pauseButton.SetActive(false);
    }
    private void Start()
    {
        if (playerInfromation.isAd == false)
        {
            panel.SetActive(false);
        }
        pausePanel.SetActive(false);
    }
    public void adOff()
    {
        
        playerInfromation.isAd = false;
        Debug.Log("Ads off");
    }
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
        //Debug.Log("NExt");
        //if (playerInfromation.isUnblocked!=true) { Debug.Log("BLOCKED"); }
        //else if (playerInfromation.isUnblocked == true)
        //{
            NumberOfLevel.text = "2";
            selectedLevel = 2;
        //}
     
    }
    public void Back()
    {
        Debug.Log("Back");
        NumberOfLevel.text = "1";
       
        selectedLevel = 1;
    }
    public void NoSound()
    {
        if (isSound)
        {
            Debug.Log("Sound off");
            isSound = false;
        }
        else
        {
            Debug.Log("Sound on");
            isSound = true;
        }
    }
  
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void BackToMenu()
    {
        Debug.Log("Back to menu");
        SceneManager.LoadScene("MainMenu");

    }
    public void Resume()
    {
        pausePanel.SetActive(false);
    }
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false); 
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
    }
}
