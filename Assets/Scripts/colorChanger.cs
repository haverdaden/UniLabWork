using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChanger : MonoBehaviour
{

    private Text Text;
    private byte Red = 150;
    private byte Green = 50;
    private byte Blue = 255;
    private bool reverse;
    private bool reverseRed;
    private bool reverseGreen;
    private bool reverseBlue;

    // Use this for initialization
	void Start ()
	{
	    Text = GetComponent<Text>();
	    Text.color = new Color32(Red, Green, Blue,255);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Red >= 255)
	    {
	        reverseRed = true;
	    }
        if (Green >= 255)
	    {
	        reverseGreen = true;
        }
        if (Blue >= 255)
	    {
	        reverseBlue = true;
        }
	    if (Red <= 0)
	    {
	        reverseRed = !reverseRed;
	    }
        if (Green <= 0)
        {
            reverseGreen = !reverseGreen;
        }
        if (Blue <= 0)
        {
            reverseBlue = !reverseBlue;
        }

	    if (reverseRed)
	    {
	        Red--;
	    }
	    else if (!reverseRed)
	    {
	        Red++;
        }
	    
	    
        
        if (reverseGreen)
	    {
	        Green--;
        }
        else
        {
            Green++;
        }
        if (reverseBlue)
	    {
	        Blue--;
        }
        else
        {
            Blue++;
        }

	    Text.color = new Color32(Red, Green, Blue,255);

        print(Green);

    }
}
