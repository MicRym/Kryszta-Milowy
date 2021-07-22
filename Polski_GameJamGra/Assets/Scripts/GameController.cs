using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    [SerializeField]
    Text Text;
    
    int TowerHealth;
    int dropCount;
    bool over_Loose=false;
    bool Over_Loose
    {
        set
        {
            over_Loose = value;
            if (over_Loose)
                OnGameOverLoose();
        }
    }
    bool over_Win=false;
    bool Over_Win
    {
        set
        {
            over_Win = value;
            if (over_Win)
                OnGameOverWin();
        }
    }
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
    public event Action OnGameOverLoose;
    public event Action OnGameOverWin;
    // Start is called before the first frame update
    void Start()
    {
        Text.GetComponent<Text>().enabled = false;
        Tower = FindObjectOfType<TowerShooting>().gameObject;
        TowerHealth = (int)Tower.GetComponent<Entity>().Health;
        Tower.GetComponent<Entity>().OnKilled += () => HPLoss();
        OnDropChange += drop => TowerProgress(drop);
        OnGameOverLoose += () => GameOver();
        OnStageChange += stage => Win(stage);
    }

    private void Win(int stage)
    {
        if(currentStage>=NumberofStages)
        {
            Text.GetComponent<Text>().enabled = true;
            Over_Win = true;
        }
            
        
    }

    private void HPLoss( )
    {
        Over_Loose = true;
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

    private void GameOver()
    {
        Debug.LogError("GameOver");
        SceneManager.LoadScene("GameOver");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
