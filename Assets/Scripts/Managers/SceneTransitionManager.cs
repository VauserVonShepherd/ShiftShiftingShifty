using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {
    public static SceneTransitionManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RunRestart()
    {
        StartCoroutine(RestartScene());
    }

    public IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu ");
    }
}
