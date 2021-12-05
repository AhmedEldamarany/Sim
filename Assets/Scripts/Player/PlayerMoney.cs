using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int money {  get; private set; }


    [SerializeField] ClothesSO clothes;
    [SerializeField] SpriteRenderer shirt;
    [SerializeField] SpriteRenderer pants;
    [SerializeField] TMP_Text moneyText;
   [HideInInspector] public TradingMaanger tradingMaanger;
   [HideInInspector] public ItemHandler itemInHand; 
   
    
    void Start()
    {
        money = clothes.MoneyAmount;
        shirt.color = clothes.Shirt;
        pants.color = clothes.Pantalon;
        updateMoneyText();
    }
    void updateMoneyText()
    {
        moneyText.text = $"${money}";

    }
    internal void LeaveItem()
    {
        itemInHand = null;
    }

    internal void Buy()
    {
        if (itemInHand == null)
               return;
        if (tradingMaanger.Trade(itemInHand))
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
        updateMoneyText();

    }
}
