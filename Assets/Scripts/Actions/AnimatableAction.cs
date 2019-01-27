using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatableAction : IAction
{

    public Animation animation;
    public Animator animator;

    public AnimatableAction(Animation a, Animator an)
    {
        animation = a;
        animator = an;
        
    }

    public IEnumerator DoAction()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
