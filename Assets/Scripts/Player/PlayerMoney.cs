using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int money {  get; private set; }
    [SerializeField] ClothesSO clothes;
    [SerializeField] SpriteRenderer shirt;
    [SerializeField] SpriteRenderer pants;

     [HideInInspector] public ItemHandler itemInHand; 
    // Start is called before the first frame update
    void Start()
    {
        money = clothes.MoneyAmount;
        shirt.color = clothes.Shirt;

    }

    internal void LeaveItem()
    {
        itemInHand = null;
    }

    internal void Buy()
    {
        if (itemInHand == null)
               return;
        if (TradingMaanger.Trade(itemInHand, this))
        {
            Debug.Log("buying");
            wear(itemInHand.color, itemInHand.isShirt);
            DeductTheCost(itemInHand.price);
            Destroy(itemInHand.gameObject);
        }
    }
     void wear(Color color, bool isShirt)
    {
        if(isShirt)
        {
            shirt.color = color;
            clothes.Shirt = color;
        }
        else
        {
            pants.color = color;
            clothes.Pantalon = color;
        }
    }
    internal void DeductTheCost(int cost)
    {
        money -= cost;
        clothes.MoneyAmount = money;
        
    }
}
