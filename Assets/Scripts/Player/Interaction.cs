using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Interaction : MonoBehaviour
{
    bool stay;
    bool hasItem;

    [SerializeField] GameObject TextMessage;
    void InteractWithShop()
    {
        stay = true;
        StartCoroutine(nameof(CheckForInput)); //better than checking in the update
        TextMessage.SetActive(true);
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
        if (stay)
        {
            stay = false;
            TextMessage.SetActive(false);
        }
    }
    IEnumerator CheckForInput()
    {
        while (stay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(1);
            
            yield return null;
        }
        yield return new WaitForEndOfFrame();
    }
    public void ExitShop()
    {
        SceneManager.LoadScene(0);
    }
}
