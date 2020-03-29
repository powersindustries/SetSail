using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLogic : MonoBehaviour
{
    // cached variables
    public Transform m_tTarget;
    [SerializeField]
    private float m_fCameraSmoothing = 5f;

    // Game Objects
    Vector3 offset;

    void Start()
    {
        offset = transform.position - m_tTarget.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPosition = m_tTarget.position + offset;

        // move camera to new targetCamPosition
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, m_fCameraSmoothing * Time.deltaTime);
    }
}
