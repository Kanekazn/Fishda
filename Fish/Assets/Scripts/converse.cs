using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class converse : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public static int day = 0;
    private int dialogueStep = 0;
    public GameObject boat;
    public GameObject rod;
    public GameObject clipboard;
    public void Start()
    {
        
    }


   
    
    void Update()
    {
        if (day == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                HandleDialogue();
            }
        }
    }

    void HandleDialogue()
    {
        switch (dialogueStep)
        {
            case 0:
                text1.text = "hey!!";
                break;
            case 1:
                text2.text = "!!!";
                break;
            case 2:
                text2.text = "What can I do for you??";
                break;
            case 3:
                text1.text = "I would like you to get me some rare fish";
                break;
            case 4:
                text1.text = "In exchange I will buy from you twice the market price";
                break;
            case 5:
                text2.text = "I'm Sorry Madam but i can't do that right now";
                break;
            case 6:
                text1.text = "Why!??";
                break;
            case 7:
                text2.text = "Because i don't have any equipment anymore and i don't also know your name";
                break;
            case 8:
                text1.text = "Don't worry i'll give you this fishing rod and boat for free";
                rod.SetActive(true);
                boat.SetActive(true);
                break;
            case 9:
                rod.SetActive(true);
                boat.SetActive(true);
                break;
            case 10:
                text1.text = "I'll give you 7 days to complete it";
                break;
            case 11:
                text2.text = "I'll try my best Madam...";
                break;
            case 12:
                text1.text = "Just call me Madam Amor";
                break;
            case 13:
                text2.text = "Ok, Madam Amor you can trust me to get you the fishes you want";
                break;
            case 14:
                text1.text = "and also any fish you caught will also be brought by me";
                break;
            case 15:
                text1.text = "Heres the list";
                clipboard.SetActive(true);
                break;
            case 16:
                text1.text = "GoodLuck";
                break;
            default:
                
                break;
        }

        
        dialogueStep++;
    }

}

