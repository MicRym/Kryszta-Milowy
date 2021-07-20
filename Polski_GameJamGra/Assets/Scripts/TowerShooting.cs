using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerShooting : MonoBehaviour
{
    public enum ShootDirection { Left, Right, Up, Down };
    // Start is called before the first frame update
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    float BulletSpeed;
    [SerializeField]
    float ShootPeriod=0.5f;
    float LastTimeShoot=0;
    Vector2 CurrentShootDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ChangeShootDirection(ShootDirection.Up);
        if (Input.GetKeyDown(KeyCode.S))
            ChangeShootDirection(ShootDirection.Down);
        if (Input.GetKeyDown(KeyCode.A))
            ChangeShootDirection(ShootDirection.Left);
        if (Input.GetKeyDown(KeyCode.D))
            ChangeShootDirection(ShootDirection.Right);

    }

    private void ShootBullet(Vector2 ShootVector)
    {
        if (Time.timeSinceLevelLoad - LastTimeShoot < ShootPeriod) return;
        LastTimeShoot = Time.timeSinceLevelLoad;
        var bullet = Instantiate(Bullet);
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.position = transform.position;
        bulletRigidbody.velocity = ShootVector.normalized * BulletSpeed;
    }
    private void ChangeShootDirection(ShootDirection shootDirection)
    {
        Vector2 ShootVector;


        switch (shootDirection)
        {
            case ShootDirection.Left:
                ShootVector= new Vector2(-1, 0.57f);
                ShootBullet(ShootVector);
                break;
            case ShootDirection.Right:
                ShootVector = new Vector2(1, -0.57f);
                ShootBullet(ShootVector);
                break;
            case ShootDirection.Up:
                ShootVector = new Vector2(1, 0.57f);
                ShootBullet(ShootVector);
                break;
            case ShootDirection.Down:
                ShootVector = new Vector2(-1, -0.57f);
                ShootBullet(ShootVector);
                break;
        }
    }
}
