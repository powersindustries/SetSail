using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    // cached variables
    public int m_iHealthPlayer = 3;
    public bool m_bPlayerIsDead = false;
    private bool m_bPlayerWasDamaged = false;
    private float m_fIndicatorFlashSpeed = 4f;

    // game objects
    public Image damageImage;
    public Color damageColor = new Color(1f, 0f, 0f, 0.1f);
    playerMovement playerMovement;
    AudioSource audio;

    void Start()
    {
        playerMovement = GetComponent<playerMovement>();
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        playerDamageIndicator();
    }

    public void playerTakeDamage()
    {
        m_iHealthPlayer--;

        m_bPlayerWasDamaged = true;

        if (m_iHealthPlayer <= 0)
        {
            playerDeath();
        }
    }

    void playerDamageIndicator()
    {
        // flashes red screen color when player takes damage
        if (m_bPlayerWasDamaged)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, m_fIndicatorFlashSpeed * Time.deltaTime);
        }
        m_bPlayerWasDamaged = false;
    }

    void playerDeath()
    {
        m_bPlayerIsDead = true;

        // turn off player audiosources
        audio.enabled = false;
        // turn off player movement
        playerMovement.enabled = false;
    }
}
