using System.Collections;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    bool stay;
    bool hasItem;


    void InteractWithShop()
    {
        stay = true;
        StartCoroutine(nameof(CheckForInput)); //better than checking in the update
    }
    void InteractWthItem(ItemHandler item)
    {
        hasItem = true;
        GetComponent<PlayerMoney>().itemInHand = item;
        item.transform.parent = transform;
    }
    void InteractWithCashier()
    {
        hasItem = false;
        GetComponent<PlayerMoney>().Buy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if (tag.Equals("shop"))
        {
            InteractWithShop();
        }
        else if (tag.Equals("item") && !hasItem)
        {
            InteractWthItem(collision.gameObject.GetComponent<ItemHandler>());
        }
        else if (tag.Equals("cashier"))
        {
            InteractWithCashier();
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
