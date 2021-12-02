using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float speed;
    float h;
    float v;
    void Start()
    {
        
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        transform.Translate(h*speed*Time.deltaTime, v * speed * Time.deltaTime, 0);
    }
}
