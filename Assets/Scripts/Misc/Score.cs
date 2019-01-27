using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
  public static int score;

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
    var baker = GameObject.Find("Baker").GetComponent<Baker>();
    var florist = GameObject.Find("Florist").GetComponent<Florist>();
    var musician = GameObject.Find("Musician").GetComponent<Musician>();
    var guard = GameObject.Find("Security Guard").GetComponent<SecurityGuard>();
    var lover = GameObject.Find("Lover").GetComponent<Lover>();

    score = baker.friendSet.Count + florist.friendSet.Count + musician.friendSet.Count + guard.friendSet.Count + lover.friendSet.Count;
  }
}