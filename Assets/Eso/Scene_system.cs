using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_system : MonoBehaviour
{
    public string Home_Name = "Home";
    public string Game_Name = "Game";
    public string Result_Name = "Result";

    public void Home_Scene()
    {
        SceneManager.LoadScene(Home_Name);
    }
    public void Game_Scene()
    {
        SceneManager.LoadScene(Game_Name);
    }
    public void Result_Scene()
    {
        SceneManager.LoadScene(Result_Name);
    }
}
