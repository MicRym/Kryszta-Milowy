using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int HP;
    [SerializeField]
    float Speed = 2.5f;
    [SerializeField]
    Vector2 Direction=new Vector2(0,0);
    [SerializeField]
    Sprite DefaultSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
