using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{
    public GameObject arrow; //for arrow
    // Update is called once per frame
    void Update()
    {
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane)); // alarm always be end of camera
        transform.position = new Vector2(topRight.x-0.5f, PlayerController.Instance.transform.position.y - 1.3f); //alert follow player's vertical pos
        if (gameObject.activeSelf) //for only spawn one arrow
        {
            StartCoroutine(callArrow()); 
        }
    }
    IEnumerator callArrow()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(arrow,transform.position,Quaternion.identity); // spawn arrow when wait 1 sec
        Destroy(gameObject); //Destroy alert and throw arrow
    }
}
