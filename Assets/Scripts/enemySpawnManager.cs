using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnManager : MonoBehaviour
{
    // cache variables
    [SerializeField]
    private float m_fSpawntime = 3f;
    private float m_fSpeedupTimer;

    // game objects
    public playerHealth playerHealth;
    public GameObject enemy;
    public Transform[] spawnPoints;

    void Start()
    {
        InvokeRepeating("Spawn", m_fSpawntime, m_fSpawntime);
    }

    void Update()
    {
        speedupTimer();
    }


    void Spawn()
    {
        // stop spawning enemies after the player dies
        if (playerHealth.m_iHealthPlayer <= 0)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }

    void speedupTimer()
    {
        m_fSpeedupTimer -= Time.deltaTime;

        if (m_fSpeedupTimer <= 0f)
        {
            // increase rate of spawn time by 1f every 15 seconds
            if (m_fSpawntime > 1)
            {
                m_fSpawntime--;
            }

            m_fSpeedupTimer = 15f;
        }
    }

}
