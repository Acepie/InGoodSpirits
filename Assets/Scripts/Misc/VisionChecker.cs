﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisionChecker : MonoBehaviour
{
  [SerializeField]
  private BoxCollider2D myCol;
  [SerializeField]
  private Sprite alerted_sprite;
  [SerializeField]
  private Sprite suspicious_sprite;
  [SerializeField]
  protected NPC parent_Script;
  [SerializeField]
  private Sprite happyFace;

    public bool isSecurityGuard = false;

  void Awake()
  {
    parent_Script = GetComponentInParent<NPC>();
  }

  //Checks for player specific detection.  set to true if you want the npc to detect 
  private bool is_playerDetectable = true;

  void FixedUpdate()
  {
    //We're facing Right/East and our local position is < 
    if ((parent_Script.direction == NPC.FacingDirection.RIGHT && transform.localPosition.x < 0)
        || (parent_Script.direction == NPC.FacingDirection.LEFT && transform.localPosition.x > 0))
    {
      transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, 0);
    }
  }

  void OnTriggerStay2D(Collider2D col)
  {
    if (col.tag.Equals("Player"))
    {
      Player player = col.gameObject.GetComponent<Player>();

      if ((is_playerDetectable && player.isCarryingItem) || isSecurityGuard && is_playerDetectable)
      {
        float x_dist = col.gameObject.transform.position.x - gameObject.transform.position.x;
        if ((parent_Script.direction == NPC.FacingDirection.RIGHT && x_dist > 0)
        || (parent_Script.direction == NPC.FacingDirection.LEFT && x_dist < 0))
        {
          parent_Script.SetEmote(suspicious_sprite, true);
        }
        else
        {
          parent_Script.SetEmote(alerted_sprite, true);
          IEnumerator cor = BeginEndGameCor(1);
          StartCoroutine(cor);

        }
      }
    }
    else if (col.tag.Equals("NPC"))
    {
      NPC otherNPC = null;
      //We're checking if we're friendly
      try
      {
        otherNPC = col.gameObject.transform.parent.gameObject.GetComponent<NPC>();
      }
      catch { }

      if (parent_Script.AreWeFriends(otherNPC))
      {
        parent_Script.SetEmote(happyFace, true);
      }
    }
  }

  public void SetPlayerDetectable(bool i_detectable)
  {
    is_playerDetectable = i_detectable;
  }

  void OnTriggerExit2D(Collider2D col)
  {
    parent_Script.SetEmoteVisibility(false);
  }

  IEnumerator BeginEndGameCor(float timetoEnd)
  {
    yield return new WaitForSeconds(timetoEnd);
    SceneManager.LoadScene("FailScene");
  }
}
