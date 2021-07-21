using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField]
    int NumberofStages = 4;
    [SerializeField]
    int BaseCostToAdvance = 30;
    [SerializeField]
    int CurrentStage = 1;
    GameObject Tower;
    int TowerHealth;
    int DropCount;
    public int dropCount
    {
        get { return DropCount; }
        set
        {
            if (OnDropChange != null)
                OnDropChange.Invoke(DropCount);
        }
    }
    public event Action<int> OnDropChange;
    // Start is called before the first frame update
    void Start()
    {
        Tower = FindObjectOfType<TowerShooting>().gameObject;
        TowerHealth = (int)Tower.GetComponent<Entity>().Health;
        Tower.GetComponent<Entity>().OnHealthChanged += health => GameOver(health);
        OnDropChange += drop => TowerProgress(drop);
    }

    private void TowerProgress(int drop)
    {
        Debug.LogWarning("Drop +1");
        if (BaseCostToAdvance <= DropCount) CurrentStage++;
    }

    private void GameOver(float health)
    {
        if(health<=0)
        Debug.LogError("GAME_OVER");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
