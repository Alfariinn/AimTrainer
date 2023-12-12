using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MainMenu();
    }

    public static void Restart()
    {
        StatCalculator.ResetStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void MainMenu()
    {
        StatCalculator.ResetStats();
        SceneManager.LoadSceneAsync("MainMenu");
        Cursor.lockState = CursorLockMode.None;
    }

    public static void Level1()
    {
        StatCalculator.ResetStats();
        SceneManager.LoadSceneAsync("Level1");
    }

    public static void Level2()
    {
        StatCalculator.ResetStats();
        SceneManager.LoadSceneAsync("Level2");
    }

    public static void Level3()
    {
        StatCalculator.ResetStats();
        SceneManager.LoadSceneAsync("Level3");
    }

    public static void Options() 
    {
        SceneManager.LoadSceneAsync("Options");
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
