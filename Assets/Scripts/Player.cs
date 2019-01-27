using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  public float initSpeed = .25f;
  public float speedGain = 1.01f;
  public float speedLoss = 1.02f;
  public float maxSpeed = 7f;
  public float controlLoss = 0;
  private int tick = 0;
  private Rect bounds = new Rect(-14f, 10f, 17, 16); 
  Rigidbody2D rb2d;
  PlayerInteractable interactableHoveringOver;
  private GameObject bodyAnim;
  private GameObject eyeAnim;
  void Start()
  {
    foreach(Transform go in transform){
      if(go.gameObject.tag == "ghostEyes"){
        eyeAnim = go.gameObject;
      } 
      if(go.gameObject.tag == "ghostBody"){
         bodyAnim = go.gameObject;
      }
    }
  }

  private void Awake()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  private void Update()
  {
    tick++;
    OnHover();
    Move();
    if (interactableHoveringOver != null && Input.GetKeyDown(KeyCode.Space))
    {
      interactableHoveringOver.OnInteract(this);
    }
  }

  private void Move()
  {
    Vector2 velocity = rb2d.velocity;
    bool up = Input.GetKey("up") || Input.GetKey("w");
    bool down = Input.GetKey("down") || Input.GetKey("s");
    bool left = Input.GetKey("left") || Input.GetKey("a");
    bool right = Input.GetKey("right") || Input.GetKey("d");

    //Bounds Checks
    bool bup =  rb2d.position.y > bounds.y;
    bool bdown = rb2d.position.y < bounds.y - bounds.height;
    bool bleft = rb2d.position.x < bounds.x;
    bool bright = rb2d.position.x > bounds.x + bounds.width;

    if((bup || bdown || bleft || bright)){
      if(bup) rb2d.position += new Vector2(0, -0.1f);
      if(bdown) rb2d.position += new Vector2(0, 0.1f);
      if(bleft) rb2d.position += new Vector2(0.1f, 0);
      if(bright) rb2d.position += new Vector2(-0.1f, 0);
      if(controlLoss <= 0){
        velocity.x = -velocity.x;
        velocity.y = -velocity.y;
        controlLoss = 15;
      }
    }

    //eyeAnimTransition("S");

    if(controlLoss > 0){
      up = down = left = right = false;
      controlLoss--;
    }

    if(up||down||left||right){
      bodyAnim.GetComponent<Animator>().SetBool("moveBool", true);
    }else{
      bodyAnim.GetComponent<Animator>().SetBool("moveBool", false);
    }

    if(up) eyeAnim.GetComponent<Animator>().SetInteger("lookDirection", 1);
    if(down) eyeAnim.GetComponent<Animator>().SetInteger("lookDirection", -1);
    if(!up && !down) eyeAnim.GetComponent<Animator>().SetInteger("lookDirection", 0);

    if (up)
    {
      if(velocity.y < .25) velocity.y = initSpeed;
      velocity.y = velocity.y * speedGain;
    }

    if (down)
    {      
      if(velocity.y > -.25) velocity.y = -initSpeed;
      velocity.y = velocity.y * speedGain;
    }

    if (left)
    {
     eyeAnim.GetComponent<SpriteRenderer>().flipX = false;
      if(velocity.x > -.25) velocity.x = -initSpeed;
      velocity.x = velocity.x * speedGain;
    }

    if (right)
    {      
      eyeAnim.GetComponent<SpriteRenderer>().flipX = true;
      if(velocity.x < .25) velocity.x = initSpeed;
      velocity.x = velocity.x * speedGain;
    }

    //Drag code, is lessened when controlLoss > 0 so drag isn't as intense
    if(controlLoss % 2 == 0){
      if(!left && !right && tick % 3 == 0){
        velocity.x = velocity.x/speedLoss;
      }
      if(!up && !down && tick % 3 == 0){
        velocity.y = velocity.y/speedLoss;
      }
    }

    velocity = maxSpeedLock(velocity);
    rb2d.velocity = velocity;
  }

  private Vector2 maxSpeedLock(Vector2 velocity){
    if(velocity.x > maxSpeed) velocity.x = maxSpeed;
    if(velocity.x < -maxSpeed) velocity.x = -maxSpeed;
    if(velocity.y > maxSpeed) velocity.y = maxSpeed;
    if(velocity.y < -maxSpeed) velocity.y = -maxSpeed;
    return velocity;
  }

  private void eyeAnimTransition(string anim){
    //Debug.Log(eyeAnim.GetCurrentAnimatorStateInfo(0));
  }

  private void OnHover()
  {
    ///Updates Focus of current object, from building, to tower, to enemy
    GameObject go = GameObjectBelowMouse();
    interactableHoveringOver = null;
    if (go != null)
    {
      MonoBehaviour[] list = go.GetComponents<MonoBehaviour>();
      foreach (MonoBehaviour mb in list)
      {
        if (mb is PlayerInteractable)
        {
          interactableHoveringOver = (PlayerInteractable)mb;
        }
      }
    }
  }

  private GameObject GameObjectBelowMouse()
  {
    GameObject clickedObject = null;

    Camera cam = Camera.main;
    RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    if (hit.collider != null)
    {
      clickedObject = hit.collider.gameObject;
    }

    return clickedObject;
  }
}
