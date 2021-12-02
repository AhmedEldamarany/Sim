using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingMaanger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public  static bool Trade(ItemHandler item, PlayerMoney player)
    {
        if (item.price > player.money)
            return false;
        else
            return true;
    }
}
