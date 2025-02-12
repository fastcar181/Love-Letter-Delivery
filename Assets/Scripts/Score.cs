using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int NumDelivered; // Number of letters delivered
    private int score; // Increases by 1 if the player delivers to the right person
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckDeliveryStatus()
    {
        if (NumDelivered == 6)
        {
            print("all letters delivered. time to check if you did good!");
            DetermineEnding();
        }

    }

    void DetermineEnding()
    {
        print("in calcscore...");
        if (NumDelivered == score)
        {
            print("congrats! you successfully delivered all the letters and turned grace back into a worm.");
        }
        else
        {
            print("oh no... you didn't deliver them successfully. it's a valentine's day disaster! grace is a worm forever and she is angry with you.");
        }
        print($"you delivered {score} letters!" );
    }
}
