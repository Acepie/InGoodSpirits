using UnityEngine;

public class Musician : NPC
{
  public AudioClip soundToPlay;
  [SerializeField]
  public Sprite musicEmote;
  new void Awake()
  {
    base.Awake();
    currentFloor = Floor.First;
    homeFloor = Floor.First;
  }
  // Use this for initialization
  private void Start()
  {
    soundToPlay = GetComponent<AudioClip>();
    SetRoutine();
    normalRoutine = routineToDo.GetActions();
    StartRoutine();
  }

  private void Update()
  {
    if (!routineToDo.isActioning)
    {
      StartRoutine();
    }
  }

  private void SetRoutine()
  {
    new DoEmote(musicEmote, this, 0.1f);
    routineToDo.AddAction(new Wait(.25f));
    routineToDo.AddAction(new EnableItem(itemToCreate));
    MusicRoutine();
  }

  private void MusicRoutine()
  {
    routineToDo.AddAction(new DoEmote(musicEmote, soundToPlay, this, 5));
    routineToDo.AddAction(new MoveTo(new Vector2(-0.9f, elevatorManager.GetDestinationPosition(Floor.First).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.First), this));
    routineToDo.AddAction(new UseElevator(this, Floor.Ground));
    routineToDo.AddAction(new MoveTo(new Vector2(4.5f, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(new Vector2(20, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(new Vector2(5.8f, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routineToDo.AddAction(new UseElevator(this, Floor.First));
    routineToDo.AddAction(new MoveTo(new Vector2(-2.4f, elevatorManager.GetDestinationPosition(Floor.First).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(GameObject.Find("Musician Room Waypoint").transform.position, this));
  }
}