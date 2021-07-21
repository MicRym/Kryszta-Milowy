using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField]
    int NumberofStages = 4;
    [SerializeField]
    int BaseCostToAdvance = 30;
    [SerializeField]
    int StageMulti = 2;
    [SerializeField]
    int currentStage = 1;
    GameObject Tower;
    int TowerHealth;
    int dropCount;
    public int DropCount
    {
        get { return dropCount; }
        set
        {
            dropCount = value;
            if (OnDropChange != null)
                OnDropChange.Invoke(dropCount);
        }
    }

    public int CurrentStage
    {
        get { return currentStage; }
        set
        {
            currentStage = value;
            if (OnStageChange != null)
                OnStageChange.Invoke(currentStage);
        } 
    }
    public event Action<int> OnDropChange;
    public event Action<int> OnStageChange;
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
        if (BaseCostToAdvance <= DropCount)
        {
            BaseCostToAdvance *= StageMulti;
            DropCount = 0;
            if(currentStage <=NumberofStages) CurrentStage++;
            Debug.Log("Obecny poziom"+CurrentStage);
        }
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
