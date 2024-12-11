using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameMenu : MonoBehaviour
{
    public int Myfish;
    public Text fishText;

    void Start()
    {
        if (fishText != null)
            fishText.text = "Fish: " + Myfish;
        else
            Debug.Log(" fishCount text is not assigned in the Inspector.");
    }
    public void Restrart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
