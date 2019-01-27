using UnityEngine;

public class Musician : NPC
{
  public AudioClip soundToPlay;
  [SerializeField]
  public Sprite musicEmote;
  new void Awake()
  {
    base.Awake();
  }
  // Use this for initialization
  private void Start()
  {
    soundToPlay = GetComponent<AudioClip>();
    SetRoutine();
    StartRoutine();
  }

  // Update is called once per frame
  private void Update()
  {
  }

  private void SetRoutine()
  {
    new DoEmote(musicEmote, this, 0.1f);
    routines.AddAction(new Wait(.25f));
    routines.AddAction(new EnableItem(itemToCreate));
    for (int i = 0; i < 5; ++i) MusicRoutine();
  }

  private void MusicRoutine()
  {
    routines.AddAction(new DoEmote(musicEmote, soundToPlay, this, 5));
    //routines.AddAction(new Wait(.1f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.First), this));
    routines.AddAction(new UseElevator(this, Floor.Ground));
    routines.AddAction(new MoveTo(new Vector2(15, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routines.AddAction(new Wait(.5f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routines.AddAction(new UseElevator(this, Floor.First));
    routines.AddAction(new MoveTo(new Vector2(4, elevatorManager.GetDestinationPosition(Floor.First).y), this));
  }
}