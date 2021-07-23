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
    float ShootDmg = 1f;
    [SerializeField]
    GameObject[] CanonsBottom;
    [SerializeField]
    GameObject[] CanonsUp;
    [SerializeField]
    GameObject[] CanonsLeft;
    [SerializeField]
    GameObject[] CanonsRight;
    [SerializeField]
    GameObject[] SpawnerBottom;
    [SerializeField]
    GameObject[] SpawnerUp;
    [SerializeField]
    GameObject[] SpawnerLeft;
    [SerializeField]
    GameObject[] SpawnerRight;
    [SerializeField]
    Sprite[] TowerSprites;
    [SerializeField]
    GameObject Tower;
    [SerializeField]
    GameObject[] Tracks;
    [SerializeField]
    Material[] TracksMaterial;
    Vector2 CurrentShootVector;
    ShootDirection CurrentShootDirection;
    void Start()
    {
        FindObjectOfType<GameController>().OnStageChange += stage => Upgrade(stage);
    }

    private void Upgrade(int stage)
    {
        Tower.GetComponent<SpriteRenderer>().sprite = TowerSprites[stage-1];
        ShootDmg += stage;
    }

    // Update is called once per frame
    void Update()
    {

        DirectionUpdate();

        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[0], SpawnerLeft[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[1], SpawnerLeft[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[2], SpawnerLeft[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 0)
            ShootBullet(CurrentShootVector, CanonsLeft[3], SpawnerLeft[3]);
        ///
        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[0], SpawnerRight[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[1], SpawnerRight[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[2], SpawnerRight[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 1)
            ShootBullet(CurrentShootVector, CanonsRight[3], SpawnerRight[3]);
        ///
        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[0], SpawnerUp[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[1], SpawnerUp[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[2], SpawnerUp[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 2)
            ShootBullet(CurrentShootVector, CanonsUp[3], SpawnerUp[3]);
        ///
        if (Input.GetKeyDown(KeyCode.Alpha1) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[0], SpawnerBottom[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[1], SpawnerBottom[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[2], SpawnerBottom[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4) && (int)CurrentShootDirection == 3)
            ShootBullet(CurrentShootVector, CanonsBottom[3], SpawnerBottom[3]);



    }

    private void ShootBullet(Vector2 ShootVector, GameObject Canon, GameObject Spawner)
    {
        if (Time.timeSinceLevelLoad - LastTimeShoot < ShootPeriod) return;
        LastTimeShoot = Time.timeSinceLevelLoad;
        var bullet = Instantiate(Bullet, gameObject.transform);
        var bulletSpriteRendere = bullet.GetComponent<SpriteRenderer>();
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        if ((int)CurrentShootDirection == 2 || (int)CurrentShootDirection == 3) bullet.GetComponent<SpriteRenderer>().flipX = true;
        switch((int) CurrentShootDirection)
        {
            case 0:
                bulletSpriteRendere.flipX = false;
               
                break;
            case 2:
                bulletSpriteRendere.flipX = true;
            
                break;
            case 1:
                bulletSpriteRendere.flipX = false;
                
                break;
            case 3:
                bulletSpriteRendere.flipX = true;
                
                break;
            default:
                break;

        }
        bullet.transform.position = Canon.transform.position;
        bullet.GetComponent<BulletDamage>().BulletTarget = Spawner;
        bullet.GetComponent<BulletDamage>().ShootDamage += ShootDmg-1;
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
        {
            ChangeShootDirection(ShootDirection.Up);
            Tracks[(int)ShootDirection.Up].GetComponent<SpriteRenderer>().material = TracksMaterial[0];
            Tracks[(int)ShootDirection.Down].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Left].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Right].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
        }
            
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeShootDirection(ShootDirection.Down);
            Tracks[(int)ShootDirection.Down].GetComponent<SpriteRenderer>().material = TracksMaterial[0];
            Tracks[(int)ShootDirection.Up].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Left].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Right].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
        }
            
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeShootDirection(ShootDirection.Left);
            Tracks[(int)ShootDirection.Left].GetComponent<SpriteRenderer>().material = TracksMaterial[0];
            Tracks[(int)ShootDirection.Up].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Down].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Right].GetComponent<SpriteRenderer>().material = TracksMaterial[1];

        }
            
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeShootDirection(ShootDirection.Right);
            Tracks[(int)ShootDirection.Right].GetComponent<SpriteRenderer>().material = TracksMaterial[0];
            Tracks[(int)ShootDirection.Up].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Down].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
            Tracks[(int)ShootDirection.Left].GetComponent<SpriteRenderer>().material = TracksMaterial[1];
        }
            
    }

    
}
