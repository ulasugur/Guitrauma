using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DifficultyManager : MonoBehaviour
{
   
  
   
   public void slowDifficulty()
   {
      SceneManager.LoadScene("Slow");
   }
   public void mediumDifficulty()
   {
      SceneManager.LoadScene("Medium");
   }
   public void fastDifficulty()
   {
      SceneManager.LoadScene("Fast");
   }
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
    public void Exit()
    {
        Application.Quit();
    }
}