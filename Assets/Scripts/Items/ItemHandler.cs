using TMPro;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    
    [SerializeField] TMP_Text text;
    [HideInInspector]public Color color;
    public int price;
    public bool isShirt;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        color= GetComponent<SpriteRenderer>().color;
        text.text = $"${price}";
    }
    public void GoToShelf()
    {
        transform.parent = null;
        transform.position = initialPosition;
    }

}
