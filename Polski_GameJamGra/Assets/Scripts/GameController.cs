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
    [SerializeField]
    GameObject Crystal;
    [SerializeField]
    GameObject Tower;
    [SerializeField]
    Text HPText;
    [SerializeField]
    Text StageText;
    [SerializeField]
    Text DropText;
    [SerializeField]
    Text WinText;
    [SerializeField]
    AudioSource AudioSource;
    [SerializeField]
    Button NewGameButton;
    [SerializeField]
    Button ExitButton;

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
        NewGameButton.onClick.AddListener(NewGameClick);
        ExitButton.onClick.AddListener(ExitClick);
        // Text.GetComponent<Text>().enabled = false;
        Tower = FindObjectOfType<TowerShooting>().gameObject;
        TowerHealth = (int)Tower.GetComponent<Entity>().initalHealth;
        Tower.GetComponent<Entity>().OnKilled += () => HPLoss();
        Tower.GetComponent<Entity>().OnHealthChanged += health => HPUpdate(health);
        OnDropChange += drop => TowerProgress(drop);
        OnGameOverLoose += () => GameOver();
        OnStageChange += stage => Win(stage);
        OnGameOverWin += () => WindOver();
        HPText.text = "Zdrowie: " + TowerHealth + "/" + TowerHealth;
        DropText.text = "Zdobyte Kryształy: " + DropCount + "/" + BaseCostToAdvance;
        StageText.text = "Fala: " + CurrentStage + "/" + (NumberofStages-1);
        WinText.enabled = false;
        
    }

    private void ExitClick()
    {
       SceneManager.LoadScene("MainMenu");
    }

    private void NewGameClick()
    {
        SceneManager.LoadScene("Game");
    }

    private void WindOver()
    {
        var crystal = Instantiate(Crystal);
        crystal.transform.position = new Vector3(0, 1.8f, 0);
        WinText.enabled = true;
        DropText.enabled = false;
        
    }

    private void HPUpdate(float health)
    {
        if (over_Win) return;
        HPText.text = "Zdrowie: " + health + "/" + TowerHealth;
        AudioSource.Play();
    }

    private void Win(int stage)
    {
        if(CurrentStage>=NumberofStages)
        {
           
            Over_Win = true;
            
            
            
        }
        Debug.LogError("Wygrałes");
        if (over_Win) return;
        StageText.text = "Fala: " + stage + "/" + (NumberofStages-1);


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
        
        DropText.text = "Zdobyte Kryształy: " + DropCount + "/" + BaseCostToAdvance;
    }

    private void GameOver()
    {
        Debug.LogError("GameOver");
        SceneManager.LoadScene("GameOver");
        
    }

}
