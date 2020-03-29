using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    // game objects
    GameObject player;
    playerHealth playerHealth;
    AudioSource crateBreak;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
        crateBreak = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // play audio of explosion
            crateBreak.Play();

            attackPlayer();

            selfDestructEnemy();
        }
    }

    private void selfDestructEnemy()
    {
        // destory self with delay (so audio can play) after hitting player
        Destroy(this.gameObject, 0.5f);
    }


    private void attackPlayer()
    {
        if(playerHealth.m_iHealthPlayer > 0)
        {
            playerHealth.playerTakeDamage();
        }
    }
}
