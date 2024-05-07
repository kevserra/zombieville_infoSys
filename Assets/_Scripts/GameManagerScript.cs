using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameoverUI;

    public static GameManagerScript instance;
    public SceneManagerScript sceneMS;
    public int totalEnemies;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyKilled()
    {
        totalEnemies--;

        if (totalEnemies <= 0)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            PlayerPrefs.GetFloat("ScoreVal");
        }
        else
        {
            Debug.Log("No more levels left to load");
        }
    }







    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (gameoverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
