using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MiniGameWinMenu : MonoBehaviour
{
    private int olemFish;
    private int solFish;
    private int olemFishCount;
    private int solFishCount;

    public Text olemFishCountText;
    public Text solFishCountText;
    public Text olemCurrentFish;
    public Text solCurrentFish;

    private MiniGameMenu findFishValue;

    void Start()
    {
        if(olemFishCountText != null)
            olemFishCountText.text = olemFishCount.ToString();
        else
            Debug.Log(" olemfishCount text is not assigned in the Inspector.");
        
        if(solFishCountText != null)
            solFishCountText.text = solFishCount.ToString();
        else
            Debug.Log(" solfishCount text is not assigned in the Inspector.");



        findFishValue = FindObjectOfType<MiniGameMenu>();
        if (findFishValue == null)
            Debug.Log("MiniGameMenu Script is not found in the scene");
    }

    public void MinusOlemFish()
    {
        olemFishCount--;
        olemFishCountText.text = olemFishCount.ToString();
    }
       public void PlusOlemFish() 
    {
        olemFishCount++;
        olemFishCountText.text = olemFishCount.ToString();
    } 

    public void MinusSolFish()
    {
        solFishCount--;
        solFishCountText.text = solFishCount.ToString();
    }
     public void PlusSolFish()
    {
        solFishCount++;
        solFishCountText.text = solFishCount.ToString();
    }
    public void Confirm()
    {
        if(findFishValue != null)
        {
            if(findFishValue.fishText != null)
            {
                if (olemFishCount > 0 && findFishValue.Myfish > 0) 
                {
                    int olemFishToTrasnfer = Mathf.Min(olemFishCount, findFishValue.Myfish);

                    if (olemFishToTrasnfer > 0)
                    {
                        olemFish += olemFishToTrasnfer;
                        findFishValue.Myfish -= olemFishToTrasnfer;
                        olemCurrentFish.text = "Olem Fish: " + olemFish;
                        findFishValue.fishText.text = "Fish: " + findFishValue.Myfish;
                    }
                }
                else if (olemFishCount < 0)
                {
                    int intialOlemFishMinus = olemFish;
                    olemFish = Mathf.Max(0, olemFish + olemFishCount);
                    int changeOlemFishMinus = intialOlemFishMinus - olemFish;
                    findFishValue.Myfish = findFishValue.Myfish + changeOlemFishMinus;

                    olemCurrentFish.text = "Olem Fish: " + olemFish;
                    findFishValue.fishText.text = "Fish: " + findFishValue.Myfish;
                }



                if (solFishCount > 0 && findFishValue.Myfish > 0) 
                {
                    int solFishToTrasnfer = Mathf.Min(solFishCount, findFishValue.Myfish);

                    if (solFishToTrasnfer > 0)
                    {
                        solFish += solFishToTrasnfer;
                        findFishValue.Myfish -= solFishToTrasnfer;
                        solCurrentFish.text = "Sol Fish: " + solFish;
                        findFishValue.fishText.text = "Fish: " + findFishValue.Myfish;
                    }
                }
                else if (solFishCount < 0)
                {
                    int intialSolFishMinus = solFish;
                    solFish = Mathf.Max(0, solFish + solFishCount);
                    int changeSolFishMinus = intialSolFishMinus - solFish;
                    findFishValue.Myfish = findFishValue.Myfish + changeSolFishMinus;

                    solCurrentFish.text = "Sol Fish: " + solFish;
                    findFishValue.fishText.text = "Fish: " + findFishValue.Myfish;
                }
            }
            else
                Debug.LogError("fishText is not assigned in findFishValue.");
        }
        else
            Debug.LogError("findFishValue is not assigned in WinMenu.");
    }
}
