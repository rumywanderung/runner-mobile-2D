using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameManager gamemanager;
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game2");
    }
}
