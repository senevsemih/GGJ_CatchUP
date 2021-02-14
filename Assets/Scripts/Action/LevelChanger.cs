using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static LevelChanger Instance = null;

    public Animator transition;
    private const float nextLevelTransitionTime = 10f;
    private const float onLevelransitionTime = 1.3f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    public void OpeningLoadLevel()
    {
        StartCoroutine(OpeningLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadNextLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(nextLevelTransitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Dead");

        yield return new WaitForSeconds(onLevelransitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    
    IEnumerator OpeningLevel(int levelIndex)
    {
        transition.SetTrigger("Dead");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}
