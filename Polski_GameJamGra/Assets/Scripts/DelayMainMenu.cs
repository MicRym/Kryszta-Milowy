using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayMainMenu : MonoBehaviour
{
    [SerializeField]
    float TimeToNextLevel = 5f;
    [SerializeField]
    string NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(TimeToNextLevel));
    }

    // Update is called once per frame
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NextLevel);
    }
}
