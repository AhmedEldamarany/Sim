using UnityEngine;

public class TradingMaanger : MonoBehaviour
{
    SFX sfx;
    [SerializeField] PlayerMoney player;

    void Start()
    {
        sfx = GetComponent<SFX>();
        player.tradingMaanger = this;
    }

    public bool Trade(ItemHandler item)
    {
        if (item.price > player.money)
        {
            item.GoToShelf();
            player.LeaveItem();
            sfx.Expensive();
            return false;
        }
        else
        {
            if (item.isShirt)
                sfx.NiceShirt();
            else
                sfx.NicePants();
           
            return true;
        }
    }
}
