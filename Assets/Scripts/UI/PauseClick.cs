using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseClick : MonoBehaviour, IClickable
{
    public void Click()
    {
        if (PlayerController.Instance.isActiveAndEnabled)
        {
            // change game's tile scale
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}
