using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]

public class Enemy : MonoBehaviour
{
    public enum SpriteDirection { Left, Right, Up, Down };
    
    [SerializeField]
    float Speed = 2.5f;
    Vector2 MoveDirection;
    [SerializeField]
    Sprite[] DefaultSprite;
    Rigidbody2D RBody;
    [SerializeField]
    SpriteDirection direction;
    SpriteRenderer Renderer;
    // Start is called before the first frame update
    private void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();
        RBody = GetComponent<Rigidbody2D>();
        /*MoveDirection =
             direction == SpriteDirection.Left ? new Vector2(-1,0.57f) :
             direction == SpriteDirection.Right ? new Vector2(1, -0.57f) :
             direction == SpriteDirection.Up ? new Vector2(1, 0.57f) : new Vector2(-1, -0.57f);*/
    }
    void Start()
    {
        GetComponent<Entity>().OnKilled += () => Die();
        SetUP();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveDirection =MoveDirection.normalized* Speed;
        RBody.velocity = MoveDirection;
    }
    void SetUP()
    {
        switch(direction)
        {
            case SpriteDirection.Left:
                MoveDirection = new Vector2(-1, 0.57f);
                try
                {
                    Renderer.sprite = DefaultSprite[(int)SpriteDirection.Left];
                }
                catch
                {
                    Debug.LogError("Brak przypisanego Sprita");
                }
                break;
            case SpriteDirection.Right:
                MoveDirection = new Vector2(1, -0.57f);
                try
                {
                    Renderer.sprite = DefaultSprite[(int)SpriteDirection.Right];
                }
                catch
                {
                    Debug.LogError("Brak przypisanego Sprita");
                }
                break;
            case SpriteDirection.Up:
                MoveDirection = new Vector2(1, 0.57f);
                try
                {
                    Renderer.sprite = DefaultSprite[(int)SpriteDirection.Up];
                }
                catch { Debug.LogError("Brak przypisanego Sprita"); }
                break;
            case SpriteDirection.Down:
                MoveDirection = new Vector2(-1, -0.57f);
                try
                {
                    Renderer.sprite = DefaultSprite[(int)SpriteDirection.Down];
                }
                catch { Debug.LogError("Brak przypisanego Sprita"); }
                break;
            default:
                MoveDirection = new Vector2(-1, 0.57f);
                Renderer.sprite = DefaultSprite[(int)SpriteDirection.Left];
                break;
        }
            
    }
}
