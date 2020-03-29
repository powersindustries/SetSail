using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class saveGameData : MonoBehaviour
{
    // public list for saving users session times
    public static List<float> savedTimes = new List<float>();
    public static float[] outputArray;
    float time;

    // game object
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();

        // set default time as zero
        savedTimes.Add(0.0f);

        getHighestScore();
    }

    void Update()
    {

        text.text ="Highest Score: " + time;
        getHighestScore();
    }

    public void addToArray(float inputValue)
    {
        savedTimes.Add(inputValue);
    }

    public void getHighestScore()
    {
        // turn list into array, for easier data management.  I like working with arrays or objects, shoot me
        outputArray = savedTimes.ToArray();

        // set output time to the max of outputArray
        time = outputArray.Max();
    }
}
