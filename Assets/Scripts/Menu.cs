using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
