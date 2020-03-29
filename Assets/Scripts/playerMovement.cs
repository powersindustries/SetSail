using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    // cached variables
    [SerializeField]
    private float m_fSpeed = 6f;
    private int m_iFloorMask;


    // Game Objects
    Vector3 movement;
    Rigidbody playerRigidBody;
    ParticleSystem wake;
    AudioSource motorSound;
    public GameObject player;

    void Awake()
    {
        m_iFloorMask = LayerMask.GetMask("Floor");
        playerRigidBody = GetComponent<Rigidbody>();
        wake = GetComponent<ParticleSystem>();
        motorSound = GetComponent<AudioSource>();

        // hide cursor and then reshow when pressing escape key
        // this is always anoying to me
        Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
    }

    private void FixedUpdate()
    {
        // pc control for input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // mobile horizontalInput
        if (Input.touchCount > 0)
        {
            Vector3 touch = Input.GetTouch(0).position;            

            if (touch.x > Screen.width * 0.5f)
            {
                horizontalInput = 1f;
            }
            else
            {
                horizontalInput = -1f;
            }
        }

        // command to move player
        movePlayer(horizontalInput);

        if (horizontalInput == 0)
        {
            makeWake();
        }

    }

    void movePlayer(float horizontal)
    {
        movement.Set(horizontal, 0f, 0f);
        // normalize direction
        movement = movement.normalized * m_fSpeed * Time.deltaTime;

        // little speed boost when pressing left shif or space, just for fun
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space))
        {
            movement *= 13f;
        }

        // tilt object slightly, apologies for the magic numbers
        Vector3 euler = transform.localEulerAngles;
        float angle = horizontal * -100.0f;
        euler.z = Mathf.Lerp(euler.z, angle, 2.0f * Time.deltaTime);
        euler.y = Mathf.Lerp(euler.z, -2.5f * angle, 2.0f * Time.deltaTime);
        transform.GetChild(0).localEulerAngles = euler;


        // jump player to other side when hitting right bound, just for kicks
        if (transform.position.x >= 50f)
        {
            player.transform.position = new Vector3(-46f, player.transform.position.y, player.transform.position.z);
        }
        // jump player to other side when hitting left bounds
        if (transform.position.x <= -48f)
        {
            player.transform.position = new Vector3(49f, player.transform.position.y, player.transform.position.z);
        }

        playerRigidBody.MovePosition(transform.position + movement);
    }

    void makeWake()
    {
        // turn on and off wake particle system
        wake.Stop();
        wake.Play();

        // turn on wake sound
        motorSound.Play();
    }

}
