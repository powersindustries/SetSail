using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScoreboardManager : MonoBehaviour
{
    // cache variable
    public int m_iPlayerHealthAmount;

    // game object
    Text text;
    GameObject player;


    public void Awake()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        text.text = "Lives Left: " + player.GetComponent<playerHealth>().m_iHealthPlayer;
    }
}
