using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public  class SoundManager : MonoBehaviour
{
    public static void PlaySound(AudioSource a)
    {
        a.Play(0);
    }
}
