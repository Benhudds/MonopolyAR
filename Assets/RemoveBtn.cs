using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class RemoveBtn : MonoBehaviour {

    public Text textObject;

    public void Remove()
    {
        Debug.Log("Button pressed");
        string note = DefaultTrackableEventHandler.TrackableNote;
        int val = 0;

        switch (note)
        {
            case "one":
                val = 1;
                break;
            case "five":
                val = 5;
                break;
            case "ten":
                val = 10;
                break;
            case "twenty":
                val = 20;
                break;
            case "fifty":
                val = 50;
                break;
            case "onehundred":
                val = 100;
                break;
            case "fivehundred":
                val = 500;
                break;
            default:
                break;
        }

        int currentVal = Int32.Parse(textObject.text.Substring(8));

        currentVal -= val;

        textObject.text = "Balance: " + currentVal;
    }
}
