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
    [SerializeField]
    GameObject[] CanonsBottom;
    [SerializeField]
    GameObject[] CanonsUp;
    [SerializeField]
    GameObject[] CanonsLeft;
    [SerializeField]
    GameObject[] CanonsRight;
    Vector2 CurrentShootVector;
    ShootDirection CurrentShootDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        DirectionUpdate();

        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[3]);
        ///
        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[3]);
        ///
        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[3]);
        ///
        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[3]);



    }

    private void ShootBullet(Vector2 ShootVector, GameObject Canon)
    {
        if (Time.timeSinceLevelLoad - LastTimeShoot < ShootPeriod) return;
        LastTimeShoot = Time.timeSinceLevelLoad;
        var bullet = Instantiate(Bullet, gameObject.transform);
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.position = Canon.transform.position;
        bulletRigidbody.velocity = ShootVector.normalized * BulletSpeed;
    }
    private void ChangeShootDirection(ShootDirection shootDirection)
    {
        CurrentShootDirection = shootDirection;
        switch (shootDirection)
        {
            case ShootDirection.Left:
                CurrentShootVector= new Vector2(-1, 0.57f);
               // ShootBullet(CurrentShootVector);
                break;
            case ShootDirection.Right:
                CurrentShootVector = new Vector2(1, -0.57f);
               // ShootBullet(CurrentShootVector);
                break;
            case ShootDirection.Up:
                CurrentShootVector = new Vector2(1, 0.57f);
               // ShootBullet(CurrentShootVector);
                break;
            case ShootDirection.Down:
                CurrentShootVector = new Vector2(-1, -0.57f);
               // ShootBullet(CurrentShootVector);
                break;
        }
    }
    void DirectionUpdate()
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
    
}
