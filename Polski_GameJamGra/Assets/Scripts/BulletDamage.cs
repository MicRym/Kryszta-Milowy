using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletDamage : MonoBehaviour
{

    GameObject Target;
    [SerializeField]
    float shootDamage = 1;
    public float ShootDamage
    {
        get { return shootDamage; }
        set { shootDamage = value; }
    }
    public GameObject BulletTarget
    {
        set { Target = value; }
    }
    private void Start()
    {
        
    }
  

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();
        if (entity != null && collision.gameObject.transform.IsChildOf(Target.transform))
        {
            entity.Health -= ShootDamage;
            Destroy(gameObject);
        }
    }
}
