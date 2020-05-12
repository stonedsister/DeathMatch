using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    
    void Start()
    {

    }

    
    void Update()
    {
       
    }

    public void Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Victory()
    {
        SceneManager.LoadScene(3);
    }

    public void Death()
    {
        SceneManager.LoadScene(4);
    }
}
