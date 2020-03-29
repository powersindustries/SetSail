using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // cache variables
    [SerializeField]
    private float m_fSpeed = 10f;
    private float m_fSpeedUpTimer;
    
    void Update()
    {
        transform.position -= transform.forward * m_fSpeed * Time.deltaTime;

        // destroy self when out of players view
        if (transform.position.z <= -15f)
        {
            Destroy(this.gameObject);
        }

        // increase object speed every 15 seconds
        m_fSpeedUpTimer -= Time.deltaTime;

        if (m_fSpeedUpTimer <= 0f)
        {
            m_fSpeed++;
            m_fSpeedUpTimer = 5f;
        }
    }
}
