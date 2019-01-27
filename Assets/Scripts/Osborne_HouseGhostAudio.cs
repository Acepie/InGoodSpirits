using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Osborne_HouseGhostAudio : MonoBehaviour
{
    //This is all the Base loop for gameplay
    public AudioSource layer1BaseLoop;
    public AudioSource layer2Lover;
    public AudioSource layer3Baker;
    public AudioSource layer4Guard;
    public AudioSource layer5Musician;
      
    //This is all the options for the ending party
    public AudioSource sadMusicianEnd;
    public AudioSource happyMusicianEnd;
    public AudioSource happyLoverEnd;
    public AudioSource happyBakerEnd;
    public AudioSource happyGuardEnd;

    //Various snapshots for fading the layers in and out
    public AudioMixerSnapshot layer1On;
    public AudioMixerSnapshot layer1Off;
    public AudioMixerSnapshot layer2On;
    public AudioMixerSnapshot layer2Off;
    public AudioMixerSnapshot layer3On;
    public AudioMixerSnapshot layer3Off;
    public AudioMixerSnapshot layer4On;
    public AudioMixerSnapshot layer4Off;
    public AudioMixerSnapshot layer5On;
    public AudioMixerSnapshot layer5Off;

    //adjustible times for fade in of layers, fadeout of layers, and how long the final fadeout is
    public float transitionIn;
    public float transitionOut;
    public float longFadeOut;

    //check to see if they're happy for the end
    private bool layer2LoverTriggered;
    private bool layer3BakerTriggered;
    private bool layer4GuardTriggered;
    private bool layer5MusicianTriggered;


    // Start is called before the first frame update
    void Start()
    {
        StartTheMusic();
        BaseLoopFade();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BaseLoopFade()
    {
        layer1On.TransitionTo(transitionIn);
        layer2Off.TransitionTo(transitionOut);
        layer3Off.TransitionTo(transitionOut);
        layer4Off.TransitionTo(transitionOut);
        layer5Off.TransitionTo(transitionOut);
    }

    public void AddLoverLoop()
    {
        layer2On.TransitionTo(transitionIn);
        layer2LoverTriggered = true;
    }

    public void AddBakerLoop()
    {
        layer3On.TransitionTo(transitionIn);
        layer3BakerTriggered = true;
    }

    public void AddGuardLoop()
    {
        layer4On.TransitionTo(transitionIn);
        layer4GuardTriggered = true;
    }

    public void StartMusicianPractice()
    {
        layer5On.TransitionTo(transitionIn);
    }

    public void StopMusicianPractice(){
        layer5Off.TransitionTo(transitionOut);
    }

    public void MusicianHappy(){
        layer5MusicianTriggered = true;
    }


    public void StartTheMusic()
    {
        layer1BaseLoop.Play();
        layer2Lover.Play();
        layer3Baker.Play();
        layer4Guard.Play();
        layer5Musician.Play();

    }

    public void StopTheLoop(){
        layer1Off.TransitionTo(longFadeOut);
        layer2Off.TransitionTo(longFadeOut);
        layer3Off.TransitionTo(longFadeOut);
        layer4Off.TransitionTo(longFadeOut);
        layer5Off.TransitionTo(longFadeOut);
    }

    public void PartyEnding(){

        StopTheLoop();

        if(layer5MusicianTriggered == false){
            sadMusicianEnd.PlayDelayed(longFadeOut-2f);
        }
        else{
            happyMusicianEnd.PlayDelayed(longFadeOut-2f);

            if (layer2LoverTriggered)
            {
                happyLoverEnd.PlayDelayed(longFadeOut-2f);
            }
            if (layer3BakerTriggered)
            {
                happyBakerEnd.PlayDelayed(longFadeOut-2f);
            }
            if (layer4GuardTriggered)
            {
                happyGuardEnd.PlayDelayed(longFadeOut-2f);
            }
        }


    }




}
