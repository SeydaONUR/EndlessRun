using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Interact()
    {
        Destroy(gameObject);
        InteractManager.interactInstance.collectCoin();
        JsonController.jsonInstance.data.numberOfCoin++;
        JsonController.jsonInstance.SaveJson(); //save total coin
    }

}
