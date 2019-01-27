using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class SoundManager : MonoBehaviour
{

    private static Osborne_HouseGhostAudio house;

    private void Awake()
    {
        house = GetComponent<Osborne_HouseGhostAudio>();
    }
    public static void PlaySound(AudioSource a)
    {
        a.Play(0);
    }

    public static void OnSuccess(NPCClass c){
        switch (c)
        {
            case NPCClass.Guard:
                house.AddGuardLoop();
                break;
            case NPCClass.Baker:
                house.AddBakerLoop();
                break;
            case NPCClass.Florist:
                
                break;
            case NPCClass.Lover:
                house.AddLoverLoop();
                break;
            case NPCClass.Musician:
                //TODO: Musician happy vs sad?
                break;
        }
    }
}
