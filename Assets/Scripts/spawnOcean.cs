using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOcean : MonoBehaviour
{
    // game objects
    public GameObject ocean;
    private float m_fTimer;

    void Update()
    {
        m_fTimer -= Time.deltaTime;

        // instantiate ocean piece every ten seconds
        if (m_fTimer <= 0f)
        {
            Instantiate(ocean);
            m_fTimer = 10f;
        }
    }
}
