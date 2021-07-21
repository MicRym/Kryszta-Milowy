using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletDamage : MonoBehaviour
{

    GameObject Target;
    public GameObject BulletTarget
    {
        set { Target = value; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();
        if (entity != null && collision.gameObject.transform.IsChildOf(Target.transform))
        {
            entity.Health -= 1f;
            Destroy(gameObject);
        } 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();
        if (entity != null && collision.gameObject.transform.IsChildOf(Target.transform))
        {
            entity.Health -= 1f;
            Destroy(gameObject);
        }
    }
}
