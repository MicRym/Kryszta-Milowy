using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    [SerializeField]
    float Time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Time);
    }

    // Update is called once per frame
  
}
