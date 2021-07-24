using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Colide : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Entity>();
       
        if(enemy!=null)
        {
            var tower =FindObjectOfType<TowerShooting>().gameObject.GetComponent<Entity>();
            tower.Health -=enemy.Health;
            collision.GetComponent<Enemy>().Boom();
            Debug.LogWarning(tower.Health);
        }

    }
}
