using UnityEngine;

public class Player : MonoBehaviour
{
  public float initSpeed = .25f;
  public float speedGain = 1.01f;
  public float speedLoss = 1.02f;
  public float maxSpeed = 7f;
  public float controlLoss = 0;
  public float itemPickupRadius = 1f;
  private int tick = 0;
  private Rect bounds = new Rect(-12f, 10f, 18, 16);
  private Rigidbody2D rb2d;
  private PlayerInteractable interactableHoveringOver;

  private bool isCarryingItem;
  private GameObject pickedUpItem;

  //State to check if we can be discovered. we are only discoverable if we're holding an object
  public bool isDiscoverable = false;

  private void Awake()
  {
    rb2d = GetComponent<Rigidbody2D>();
    isDiscoverable = false;
  }

  // Update is called once per frame
  private void Update()
  {
    tick++;
    OnHover();
    Move();
    ItemInteractions();
  }

  private void ItemInteractions()
  {
    if (interactableHoveringOver != null && Input.GetKeyDown(KeyCode.Space))
    {
      interactableHoveringOver.OnInteract(this);
    }
    else if (isCarryingItem && Input.GetKeyDown(KeyCode.Space))
    {
      DropItem();
    }
  }

  private bool ItemWithinRadius(Vector3 itemPos)
  {
    return Vector3.Distance(itemPos, transform.position) < itemPickupRadius;
  }

  private void Move()
  {
    Vector2 velocity = rb2d.velocity;
    bool up = Input.GetKey("up") || Input.GetKey("w");
    bool down = Input.GetKey("down") || Input.GetKey("s");
    bool left = Input.GetKey("left") || Input.GetKey("a");
    bool right = Input.GetKey("right") || Input.GetKey("d");

    //Bounds Checks
    bool bup = rb2d.position.y > bounds.y;
    bool bdown = rb2d.position.y < bounds.y - bounds.height;
    bool bleft = rb2d.position.x < bounds.x;
    bool bright = rb2d.position.x > bounds.x + bounds.width;

    if (controlLoss <= 0 && (bup || bdown || bleft || bright))
    {
      if (bup) rb2d.position += new Vector2(0, 0.1f);
      if (bdown) rb2d.position += new Vector2(0, -0.1f);
      if (bleft) rb2d.position += new Vector2(-0.1f, 0);
      if (bright) rb2d.position += new Vector2(0.1f, 0);
      velocity.x = -velocity.x;
      velocity.y = -velocity.y;
      controlLoss = 15;
    }

    if (controlLoss > 0)
    {
      up = down = left = right = false;
      controlLoss--;
    }

    if (up)
    {
      if (velocity.y < .25) velocity.y = initSpeed;
      velocity.y = velocity.y * speedGain;
    }

    if (down)
    {
      if (velocity.y > -.25) velocity.y = -initSpeed;
      velocity.y = velocity.y * speedGain;
    }

    if (left)
    {
      if (velocity.x > -.25) velocity.x = -initSpeed;
      velocity.x = velocity.x * speedGain;
    }

    if (right)
    {
      if (velocity.x < .25) velocity.x = initSpeed;
      velocity.x = velocity.x * speedGain;
    }

    //Drag code, is lessened when controlLoss > 0 so drag isn't as intense
    if (controlLoss % 2 == 0)
    {
      if (!left && !right && tick % 3 == 0)
      {
        velocity.x = velocity.x / speedLoss;
      }
      if (!up && !down && tick % 3 == 0)
      {
        velocity.y = velocity.y / speedLoss;
      }
    }

    velocity = maxSpeedLock(velocity);
    rb2d.velocity = velocity;
  }

  private Vector2 maxSpeedLock(Vector2 velocity)
  {
    if (velocity.x > maxSpeed) velocity.x = maxSpeed;
    if (velocity.x < -maxSpeed) velocity.x = -maxSpeed;
    if (velocity.y > maxSpeed) velocity.y = maxSpeed;
    if (velocity.y < -maxSpeed) velocity.y = -maxSpeed;
    return velocity;
  }

  private void OnHover()
  {
    GameObject go = GameObjectBelowMouse();
    interactableHoveringOver = null;
    if (go != null)
    {
      MonoBehaviour[] list = go.GetComponents<MonoBehaviour>();
      foreach (MonoBehaviour mb in list)
      {
        if (mb is PlayerInteractable && ItemWithinRadius(mb.transform.position))
        {
          interactableHoveringOver = (PlayerInteractable)mb;
          Debug.Log("Close and over");
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

  public void PickUp(PickupInteractable api)
  {
    if (!isCarryingItem)
    {
      pickedUpItem = api.gameObject;
      isCarryingItem = true;
    }
    else
    {
      DropItem();
      pickedUpItem = api.gameObject;
      isCarryingItem = true;
    }
  }

  private void DropItem()
  {
    pickedUpItem.GetComponent<PickupInteractable>().Drop(transform.position);
    isCarryingItem = false;
  }
}