using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // cache variables
    [SerializeField]
    private float m_fRestartDelay = 10f;
    [SerializeField]
    private float m_fRestartTimer;

    // game objects
    public playerHealth playerHealth;
    public GameObject player;
    public Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();

    }


    void Update()
    {
        if (playerHealth.m_iHealthPlayer <= 0)
        {
            anim.SetTrigger("GameOver");

            m_fRestartTimer += Time.deltaTime;

            if (m_fRestartTimer >= m_fRestartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
