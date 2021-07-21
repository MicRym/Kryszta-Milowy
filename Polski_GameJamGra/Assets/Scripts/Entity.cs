using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    [SerializeField]
    float InitialHealth=10f;

    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {

            health = value;
            if (OnHealthChanged != null)
                OnHealthChanged.Invoke(health);
           
            if (health <= 0)
            {
                if (OnKilled != null)
                    OnKilled.Invoke();
                Destroy(gameObject);
            }
                
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = InitialHealth;
    }
    public event Action<float> OnHealthChanged;
    public event Action OnKilled;
    // Update is called once per frame
    void Update()
    {
        
    }
}
