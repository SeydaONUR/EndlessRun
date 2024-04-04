using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinUI : MonoBehaviour
{
    private int inRoundCoin; //if die or retry reset coin
    public Text coinText;
    void Start()
    {
        inRoundCoin = 0; //Start 
        coinText.text = inRoundCoin.ToString();
        InteractManager.interactInstance.coinUI += coinUI;
    }
    private void coinUI()
    {
        Debug.Log("UI coin");
        inRoundCoin++;
        coinText.text = inRoundCoin.ToString(); //update when take coin
    }
}
