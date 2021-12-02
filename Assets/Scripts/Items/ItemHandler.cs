using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] ItemSO itemSO;
    [SerializeField] TMP_Text text;
    public int price;
    public Color color;
    public Vector3 initialPosition;
    public bool isShirt;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        if (itemSO != null)
        {
            color = itemSO.color;
            GetComponent<SpriteRenderer>().color = color;
            price = itemSO.price;
            text.text = $"{price}$";
            isShirt = itemSO.isShirt;
        }
    }
    public void GoToShelf()
    {
        transform.parent = null;
        transform.position = initialPosition;
    }
    
}
