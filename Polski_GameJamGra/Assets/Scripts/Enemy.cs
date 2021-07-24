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
    GameObject Drop;
    [SerializeField]
    float Speed = 2.5f;
    Vector2 MoveDirection;
    Rigidbody2D RBody;
    [SerializeField]
    SpriteDirection direction;
    [SerializeField]
    ParticleSystem DeathParticle;
    public SpriteDirection Direction
    {
        get { return direction; }
        set { direction = value; }
    }
    
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
      //  FindObjectOfType<GameController>().OnGameOverWin += () => Die();
        SetUP();
    }

    private void Die()
    {
        var particleInstance = Instantiate(DeathParticle);
        particleInstance.transform.position = transform.position;
        var dropInstance=Instantiate(Drop);
        dropInstance.transform.position = transform.position;
        Destroy(particleInstance, 2);
        Destroy(gameObject);
        
    }
    public void Boom()
    {
        var particleInstance = Instantiate(DeathParticle);
        particleInstance.transform.position = transform.position;
        Destroy(particleInstance, 2);
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
                Renderer.flipX = false;                            
                break;
            case SpriteDirection.Right:
                Renderer.flipX = false;
                MoveDirection = new Vector2(1, -0.57f);
               
                break;
            case SpriteDirection.Up:
                Renderer.flipX = true;
                MoveDirection = new Vector2(1, 0.57f);
                break;
            case SpriteDirection.Down:
                Renderer.flipX = true;
                MoveDirection = new Vector2(-1, -0.57f);
               break;
            default:
                MoveDirection = new Vector2(-1, 0.57f);
             
                break;
        }
            
    }
}
