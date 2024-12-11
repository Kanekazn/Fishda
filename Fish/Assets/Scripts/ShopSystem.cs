using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{
    
    public int myMoney = 100;
    public Text MoneyTxt;
    public GameObject noMoney;

    private GameObject[] buyButtons;
    private GameObject[] disabledButtons;


    private void Start()
    {

        buyButtons = GameObject.FindGameObjectsWithTag("BuyButton");
        disabledButtons = GameObject.FindGameObjectsWithTag("DisabledButton");

        MoneyTxt.text = "Money: " + myMoney;

        noMoney.SetActive(false);


        foreach (GameObject buttonObj in buyButtons)
        {
            Button button = buttonObj.GetComponent<Button>();
            if (button == null)
                Debug.LogWarning("Button component not found on " + buttonObj.name);

            if (button != null)
                button.interactable = true;
            else
                Debug.LogWarning("Button component not found on " + buttonObj.name);
        }

        foreach (GameObject disbuttonObj in disabledButtons)
        {
            Button disButton = disbuttonObj.GetComponent<Button>();
            if (disButton == null)
                Debug.LogWarning("Disabled Buttons component not found on " + disbuttonObj.name);
            else
                disButton.interactable = false;
        }
    }

    public void Buy(int product)
    {
        if (noMoney == null)
        {
            Debug.LogError("noMoney is not assigned!");
            return;
        }

        if (EventSystem.current == null)
        {
            Debug.LogError("Event System is not present!");
            return;
        }

        if (noMoney.activeSelf)
        {
            return;
        }

        if (myMoney >=  product)
        {
            myMoney = myMoney - product;
            
            MoneyTxt.text = "Money: " + myMoney;


            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
            if (clickedButton == null)
            {
                Debug.LogError("Clicked button is null!");
                return;
            }

           clickedButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            noMoney.SetActive(true);
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
           //clickedButton.GetComponent<Button>().interactable = false;
        }    
    }


}

