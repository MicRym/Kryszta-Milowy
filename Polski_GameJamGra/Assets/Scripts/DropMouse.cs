using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        //Debug.LogWarning("Postęp +1");
        FindObjectOfType<GameController>().dropCount++;
        Destroy(gameObject);

    }
}
