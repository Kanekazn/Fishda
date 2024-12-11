using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timer;
     public GameObject Menu;
    
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else if (timer < 0)
        {
            timer = 0;
            timerText.color = Color.green;
            Time.timeScale = 0;
            Menu.SetActive(true);

        }

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }


}
