using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            PlayerPrefs.SetFloat("ScoreVal", scoreManager.GetScore());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
