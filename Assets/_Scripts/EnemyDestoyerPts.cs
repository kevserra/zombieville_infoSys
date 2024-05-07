using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestoyerPts : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float scoreValue = 100f;

    private void OnDestroy()
    {
        if(scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
