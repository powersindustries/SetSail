using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeScoreboardManager : MonoBehaviour
{
    // cache variable
    private static float time;
    private bool m_bIsTimerOn = true;

    // game object
    Text text;
    public playerHealth playerHealth;
    public GameObject saveGameData;


    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        timeScoreboard();
        text.text = "Time: " + time;

        // stop clock when player dies, otherwise time.timeSinceLevelLoad will keep going for a few seconds
        if (playerHealth.m_iHealthPlayer <= 0)
        {
            m_bIsTimerOn = false;
            saveGameData.GetComponent<saveGameData>().addToArray(time);

        }
    }

    private void timeScoreboard()
    {
        if (m_bIsTimerOn == true)
        {
            time = Time.timeSinceLevelLoad;
        }
    }


}
