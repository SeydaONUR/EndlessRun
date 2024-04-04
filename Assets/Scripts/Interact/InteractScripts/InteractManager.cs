using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InteractManager : MonoBehaviour
{
    public static InteractManager interactInstance;
    public event Action coinUI; // for update coin ui when take coin
    public event Action gameOver;
    private void Awake()
    {
        interactInstance = this; // initialize
    }
    // All interaction's code
    public void collectCoin()
    {
        Debug.Log("Collect Coin");
        coinUI?.Invoke(); // for change Coin UI's
    }
    public void MouseTrap()
    {
        if (DashController.dashInst.dashing == false)
        {
            gameOver?.Invoke(); //if player dies
            PlayerController.Instance.gameObject.SetActive(false);
            //Change trap animaiton
        }
        if (DashController.dashInst.dashing)
        {
            // If player making dash breake trap
        }
    }
    public void Arrow()
    {
        if (DashController.dashInst.dashing != true)
        {
            PlayerController.Instance.gameObject.SetActive(false);
            gameOver?.Invoke(); //if player dies
        }
    }
    public void Enemy()
    {
        if (DashController.dashInst.dashing != true)
        {
            PlayerController.Instance.gameObject.SetActive(false);
            gameOver?.Invoke(); //if player dies
        }
    }
    public void Rock()
    {
        Debug.Log("Rock");
        PlayerController.Instance.gameObject.SetActive(false); // player destroy for all states
        gameOver?.Invoke(); //if player dies
    }
}
