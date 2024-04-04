using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    void Start()
    {
        InteractManager.interactInstance.gameOver += Gameover;
    }
    private void Gameover()
    {
        Debug.Log("Game over");
        Time.timeScale = 0f; //if player dead stop game
    }
}
