using UnityEngine;

public class Baker : NPC
{

    new void Awake()
    {
        base.Awake();
    }
    // Use this for initialization
    private void Start()
    {
        SetRoutine();
        StartRoutine();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void SetRoutine()
    {
        routines.AddAction(new Wait(.25f));
        routines.AddAction(new EnableItem(itemToCreate));
    }
}