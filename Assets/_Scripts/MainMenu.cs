using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioSource menuTheme;
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        menuTheme.Stop();
    }
  
    public void QuitGame()
    {
        Debug.Log("Quit Working");
        Application.Quit();
    }
}
