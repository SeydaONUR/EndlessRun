using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    [Header("Simple Movement")]
    public Rigidbody2D rb;
    public Animator anim;
    [Space]
    [Header("Jump")]
    public float jumpForce;
    public Transform groundPoint;
    private float range=0.2f; 
    public LayerMask ground;
    [Header("PowerUp")]
    public bool canGlide;
    [Header("Trampoline")]
    public bool falling;
    [Header("Singleton")]
    public static PlayerController Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        falling = false;
        canGlide = false;
    }
    private void FixedUpdate()
    {
        if (falling)
        {
            rb.velocity = new Vector2(rb.velocity.x,-13f); //fall faster and if collision trampoline jump higher
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) // touch falling
        {
            Touch touch = Input.GetTouch(0);
            if (touch.deltaPosition.y < -50f)
            {
                falling = true; //if we scroll down
            }
        }
        if (onGround())
        {
            rb.gravityScale = 1f;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(touch, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "UI") // if we  touch ui player can't jump
                {
                    IClickable click = hit.collider.gameObject.GetComponent<IClickable>();
                    if (click != null)
                    {
                        click.Click(); //call ui func
                    }
                }
                else if (hit.collider.tag != "UI" && onGround())
                {
                    Jump(); //if touch another place
                }
            }
            else if (onGround() && hit.collider == null)
            {
                Jump(); // don't have collider
            }
        }
            AnimationController();
        }
    public bool onGround() //take ground or note
    {
        bool groundMu= Physics2D.OverlapCircle(groundPoint.position, range, ground);
        return groundMu;
    }
    #region Jumps
    public void Jump() //Jump
        {
            rb.velocity = Vector2.up * jumpForce; // for jump and trampoline
        
        }
    public void trampolineJump(bool falling) //Jump with trampoline
    {
        if (falling)
        {
            rb.velocity = Vector2.up * jumpForce * 1.4f; // for jump and trampoline
        }
        else
        {
            rb.velocity = Vector2.up * jumpForce; // for jump and trampoline
        }
    }
    #endregion
    private void AnimationController()
    {
        anim.SetFloat("Vertical", rb.velocity.y);
        anim.SetBool("onGround",onGround());

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tile") //if player hit tile change falling
        {
            falling = false;
        }
    }
}
