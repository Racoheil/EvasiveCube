using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsControll : MonoBehaviour
{
    public GameObject panel;
    public int selectedLevel=1;
    public static ButtonsControll instance;
    public bool isSound;
    public TMP_Text NumberOfLevel;
    public GameObject ShopWindow, MainMenuWindow,SettingsWindow;
 
    private void Start()
    {
        
    }
    public void restartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void adOff()
    {
        

        Debug.Log("Ads off");
    }
    private void Awake()
    {
        instance = this;
    }
    public void Play()
    {
        Debug.Log("PLAY");
        SceneManager.LoadScene("Level" + selectedLevel);
    }
    public void GoToShop()
    {
        Debug.Log("go to shop");
        ShopWindow.gameObject.SetActive(true);
        MainMenuWindow.gameObject.SetActive(false);

    }
    public void SignUpIn()
    {
        Debug.Log("SIGN");
    }
    public void Settings()
    {
        Debug.Log("Settings");
        SettingsWindow.gameObject.SetActive(true);
        MainMenuWindow.gameObject.SetActive(false);
    }
    public void Next()
    {
        Debug.Log("Next");
        selectedLevel += 1;
        NumberOfLevel.text = selectedLevel.ToString() ;
            
        
     
    }
    public void Back()
    {
        Debug.Log("Back");
        selectedLevel -= 1;
        NumberOfLevel.text =selectedLevel.ToString();
       
        
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
     

       ShopWindow.gameObject.SetActive(false);
       SettingsWindow.gameObject.SetActive(false);
        MainMenuWindow.gameObject.SetActive(true);

    }
   public void goToNextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
