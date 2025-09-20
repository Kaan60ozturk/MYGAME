using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void startgame()

    {
        SceneManager.LoadScene("13.09 son hal");

    }   
    
    public void exitgame()

    {
        Application.Quit();

    }


    public void Settings()
    {
        SceneManager.LoadScene("Settings"); // "Settings" adlý sahneyi açar
    }

}
