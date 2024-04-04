using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryClick : MonoBehaviour, IClickable
{
    public void Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //retry active scene
        Time.timeScale = 1;
    }
}
