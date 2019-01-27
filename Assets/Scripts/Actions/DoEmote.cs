using System.Collections;
using UnityEngine;

/// <summary>
/// Does an emote and plays a sound if you want it to
/// </summary>
public class DoEmote : IAction
{

    public Sprite emote;
    NPC npc;
    public AudioSource audio;
    float waitTime;

/// <summary>
/// Emote without sound
/// </summary>
/// <param name="s">emote to display</param>
/// <param name="n">npc</param>
/// <param name="f">time emote is visible</param>
    public DoEmote(Sprite s, NPC n, float f)
    {
        emote = s;
        npc = n;
        waitTime = f;
    }

/// <summary>
/// Emote with sound effect
/// </summary>
/// <param name="s">Emote to show</param>
/// <param name="a_s">Sound effect to play</param>
/// <param name="n">NPC</param>
/// <param name="f">Time emote is visible</param>
    public DoEmote(Sprite s, AudioSource a_s, NPC n, float f)
    {
        emote = s;
        audio = a_s;
        npc = n;
        waitTime = f;
    }

    public IEnumerator DoAction()
    {
        npc.SetEmote(emote, true);
        if(audio != null)
        {
            SoundManager.PlaySound(audio);
        }
        yield return new WaitForSeconds(waitTime);
        npc.SetEmoteVisibility(false);
        yield return null;
    }
}
