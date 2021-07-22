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
       
        FindObjectOfType<GameController>().DropCount++;
       Debug.LogWarning("Obecny drop "+FindObjectOfType<GameController>().DropCount);
        Destroy(gameObject);

    }
}
