using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameEndCondition : MonoBehaviour
{

    private GameObject loseMenuWindow;
    private Transform canvasTransform;


    void Start()
    {

        canvasTransform = GameObject.Find("Canvas").transform;

        if(canvasTransform != null )
        {
            loseMenuWindow = canvasTransform.Find("Lose Menu").gameObject;

            if (loseMenuWindow != null)
                loseMenuWindow.SetActive(false);
            else
            {
                Debug.Log("ERROR: Lose Menu GameObject not found under Canvas. Please check the hierarchy and name.");

            }

        }
        else
            Debug.LogError("ERROR: Canvas GameObject not found in the scene. Please ensure a Canvas exists.");
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (loseMenuWindow != null)
            {
                loseMenuWindow.SetActive(true);
                Time.timeScale = 0;
            }
            else
                Debug.LogError("ERROR: Lose Menu GameObject is not assigned. Cannot show the menu.");


        }
        else
            Debug.LogWarning("Collision detected, but it was not with the Player.");
    }
}
