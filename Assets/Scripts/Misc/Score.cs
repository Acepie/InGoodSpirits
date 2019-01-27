using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
  public static bool displaySecurity = false;
  public static bool displayBaker = false;
  public static bool displayFlorist = false;
  public static bool displayLover = false;

  public static int score = 0;


  void Update()
  {
    if (TimeManager.gameEnded())
    {
      computeTotal();
      SceneManager.LoadScene("EndScene");
    }
  }

  public void computeTotal()
  {
    var musician = GameObject.Find("Musician").GetComponent<Musician>();
    score = musician.friendSet.Count;
    foreach (NPC n in musician.friendSet)
    {
      switch(n.gameObject.name) 
      {
        case "Security Guard" :
        {
          Score.displaySecurity = true;
          break;
        } 
        case "Lover" :
        {
           Score.displayLover = true;
          break;
        }
        case "Florist" :
        {
          Score.displayFlorist = true;
          break;
        }
        case "Baker" :
        {
          Score.displayBaker = true;
          break;
        }
      }
    }
  }
}