using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public Text scoreValText;
    public float scoreVal = 0f;
    public float maxScore = 9999f;
    public float ptIncPerSec = 1f;

    public GameObject prefabZombie;

    public void AddScore(float scoreToAdd)
    {
        scoreVal += scoreToAdd;
    }

    void FixedUpdate()
    {
        scoreValText.text = ((int)scoreVal).ToString();
        scoreVal += ptIncPerSec * Time.fixedDeltaTime;

    }

    public float GetScore()
    {
        return scoreVal;
    }
}
