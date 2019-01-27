using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour
{

    public Osborne_HouseGhostAudio audioSet; 
    // Start is called before the first frame update
    void Awake()
    {
        audioSet.StartTheMusic();
        if (Score.score > 2)
        {
            audioSet.MusicianHappy();
        }
    }
}
