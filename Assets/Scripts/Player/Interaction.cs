using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    bool stay;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("shop"))
        {

        stay = true;
        StartCoroutine(nameof(CheckForInput)); //better than checking in the update
        }
        else if (collision.tag.Equals("item"))
        {
            ItemHandler item = collision.gameObject.GetComponent<ItemHandler>();
            GetComponent<PlayerMoney>().Buy(item);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        stay = false;
    }
    IEnumerator CheckForInput()
    {
        while (stay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Buy from here");
            
        yield return null;
        }
        yield return new WaitForEndOfFrame();
    }

}
