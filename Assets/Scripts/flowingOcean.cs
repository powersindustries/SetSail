using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowingOcean : MonoBehaviour
{
    // cache variables
    [SerializeField]
    private float m_fSpeed = 10f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * -1f * m_fSpeed * Time.deltaTime, Space.World);

        // destroy self when out of players view
        if (transform.position.z <= -20f)
        {
            Destroy(this.gameObject);
        }
    }
}

