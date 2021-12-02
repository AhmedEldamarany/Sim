using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int money {  get; private set; }
    [SerializeField] ClothesSO clothes;
    SpriteRenderer shirt;
    // Start is called before the first frame update
    void Start()
    {
        money = 5;
        shirt = GetComponent<SpriteRenderer>();
        shirt.color = clothes.Shirt;

    }
    public void Buy(ItemHandler item)
    {
        if (TradingMaanger.Trade(item, this))
        {
            shirt.color = item.color;
            clothes.Shirt = item.color;
        }
    }
}
