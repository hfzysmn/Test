using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void loadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
