using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private static int NumDelivered = 0; // Number of letters delivered
    private static int ScoreNum = 0; // Increases by 1 if the player delivers to the right person
    public static bool end = false;

    public static bool CheckDeliveryStatus()
    {
        Debug.Log(ScoreNum);
        if (NumDelivered == 6)
        {
            return true;
        }
        return false;
    }

    public static void IncreaseNumDelivered()
    {
        NumDelivered++;
    }

    public static void IncreaseScoreNum()
    {
        ScoreNum++;
    }

    public static void DetermineEnding()
    {
        end = true;
        if (NumDelivered == ScoreNum)
        {
            Debug.Log("YOU WON!");
        }
        else
        {
            Debug.Log("YOU LOSE BAI!");
        }
        Debug.Log($"you delivered {ScoreNum} letters!");
        Application.Quit();
    }
}
