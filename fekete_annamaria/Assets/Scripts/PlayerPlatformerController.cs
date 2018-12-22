using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;


    private bool canDoubleJump;
    [SerializeField] private bool doubleJumpMode;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector3 startingpos;

    public bool left;

    private bool crouching;
    public bool vining;

    private float gravitysc;
    private float gravitym;

    public GameObject _gm;

    

    // Use this for initialization
    void Awake () 
    {
        startingpos = this.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
        gravitysc = GetComponent<Rigidbody2D>().gravityScale;
        gravitym = GetComponent<PhysicsObject>().gravityModifier;
        
    }

    protected override void ComputeVelocity()
    {
        if(!crouching)
        {

            Vector2 move = Vector2.zero;

            move.x = Input.GetAxis ("Horizontal");

            if(Input.GetButtonDown ("Jump")){
                if ( grounded ||  vining  ){
                    GetComponent<AudioSource>().Play();
                    velocity.y = jumpTakeOffSpeed;
                    if(vining)
                    {
                        GetComponent<Rigidbody2D>().gravityScale = gravitysc;
                        GetComponent<PhysicsObject>().gravityModifier = gravitym;
                        vining = false;
                        animator.SetBool ("vining", false);
                    }
                    if(doubleJumpMode){
                        canDoubleJump = true;
                    }
                    
                } 
                else if (canDoubleJump) {
                    canDoubleJump = false;
                    velocity.y = jumpTakeOffSpeed;
                }
            }

            else if (Input.GetButtonUp ("Jump") && !vining) 
            {
                if (velocity.y > 0) {
                    velocity.y = velocity.y * 0.5f;
                }
            }

            bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
            if (flipSprite && move.x != 0) 
            {
                left = true;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
            else{
                left = false;
            }

            animator.SetBool ("grounded", grounded);
            animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
            if(!vining || Input.GetButtonDown ("Jump"))
            {
                targetVelocity = move * maxSpeed;
            }
        }

        if(!vining)
        {
            if(Input.GetButtonDown("Crouch"))
            {
                animator.SetBool ("crouching", true);
                crouching = true;
            }
            if(Input.GetButtonUp("Crouch"))
            {
                animator.SetBool ("crouching", false);
                crouching = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Vine")
        {   
           // Debug.Log("ENTERED");
            //Physics2D.gravity = new Vector2(0,0);
           
            GetComponent<Rigidbody2D>().gravityScale = 0;
             GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<PhysicsObject>().gravityModifier = 0;

            transform.position = new Vector3(other.transform.position.x, other.transform.position.y-4, transform.position.z);
            vining=true;

            transform.parent = other.transform;
            
            animator.SetBool ("vining", true);
        }

        // if(other.gameObject.tag == "Crystal")
        // {
        //     Debug.Log("ENTERED");
        //     Destroy(other.gameObject);
        //     _gm.GetComponent<AudioSource>().Play();
        //     GameManager.Instance.AddPoint(1);
        // }

        if(other.gameObject.tag == "HitChecker")
        {
            this.transform.position = startingpos;
            other.GetComponent<AudioSource>().Play();
        }

        if(other.gameObject.tag == "chkpoint")
        {
            startingpos = this.transform.position;
            other.GetComponent<AudioSource>().Play();
            for (int i = 0; i < 5; i++)
            {
                other.transform.GetChild(i).gameObject.SetActive(true);
            }
            
            CheckPoint chkPint = (CheckPoint)other.GetComponent(typeof(CheckPoint));
            chkPint.rotate = true;
        }

        if(other.gameObject.tag == "Button")
        {
            other.gameObject.GetComponent<ButtonScript>().playerHere = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Button")
        {
            other.gameObject.GetComponent<ButtonScript>().playerHere = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "MovingTile")
        {
            transform.parent = other.transform;
        }
        
        if(other.gameObject.tag == "MovableRock")
        {
           // Debug.Log("ROCK ENTERED");
            isMovableRock = true;
        }

        if(other.gameObject.tag == "bouncer")
        {
            velocity.y = (float)(1.5*jumpTakeOffSpeed);
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "MovingTile")
        {
            transform.SetParent(null);
        }

        if(other.gameObject.tag == "MovableRock")
        {
            isMovableRock = false;
        }
	}
}