using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletDamage : MonoBehaviour
{

    GameObject Target;
    [SerializeField]
    int DamageMulti = 1;
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
            entity.Health -= 1f*DamageMulti;
            Destroy(gameObject);
        }
    }
}
