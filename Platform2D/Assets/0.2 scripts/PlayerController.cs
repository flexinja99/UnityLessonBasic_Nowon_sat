using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private GroundDetector groundDetector;
    public float jumpForce;
    public float moveSpeed;
    private float moveInputOffset = 0.1f;
    Vector2 move;

    int _direction; // +1 : right, -1 : left

   public int direction
    {
        set
        {
            if (value < 0)
            {
                _direction = -1;
                transform.eulerAngles = new Vector3(0, 180f, 0);
            }
            else if (value > 0)
            {
                _direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
        get
        {
            return _direction;
        }
    }


            
   


    public PlayerState state;
    public Jumpstate jumpState;
    public FallState fallState;

    private float jumpTime = 0.1f;
    private float jumpTimer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundDetector = GetComponent<GroundDetector>();
    }
    private void Update()
    {
       float h=Input.GetAxis("Horizontal");
       // 방향전환
       if (h < 0) direction = -1;
       else if (h > 0) direction = 1;

       if(Mathf.Abs(h) > moveInputOffset)
       {
            move.x = h;
            if (state == PlayerState.Idle)
                ChagePlayerState(PlayerState.Run);
       }
        
        else
        {
            move.x = 0;
            if (state == PlayerState.Run)
                ChagePlayerState(PlayerState.Idle);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (groundDetector.isDetected&&
                state != PlayerState.Jump&&
                state != PlayerState.Fall)
            { 
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                state = PlayerState.Jump;
            }
        }
       
        UpdatePlayerstate();
       
    }

    private void FixedUpdate()
    {
        rb.position += new Vector2(move.x * moveSpeed, move.y) * Time.fixedDeltaTime;
    }
    public void ChagePlayerState(PlayerState newState)
    {
        if (state == newState) return;

        //이전 상태 하위 머신 초기화
        switch (state)
        {
            case PlayerState.Idle:
                
                break;
            case PlayerState.Run:
                
                break;
            case PlayerState.Jump:
                jumpState = Jumpstate.Idle;
                break;
            case PlayerState.Fall:
               fallState = FallState.Idle;

                break;
            default:
                break;
                   
        }

        // 현재 상태 바꿈
        state = newState;
        switch (state)
        {
            case PlayerState.Idle:

                break;
            case PlayerState.Run:

                break;
            case PlayerState.Jump:
                jumpState = Jumpstate.Prepare;
                break;
            case PlayerState.Fall:
                fallState = FallState.Prepare;

                break;
            default:
                break;
        }


    }
    private void UpdatePlayerstate()
    {
        switch (state)
        {
            case PlayerState.Idle:

                break;
            case PlayerState.Run:

                break;
            case PlayerState.Jump:
                UpdateJumpstate();
                break;
            case PlayerState.Fall:
                UpdateFallState();
                break;
            default:
                break;
        }
    }     
         
    private void UpdateJumpstate()
    {
        switch (jumpState)
        {
            case Jumpstate.Idle:
                break;
            case Jumpstate.Prepare:
                animator.Play("Jump");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpTimer = jumpTime;
                jumpState++;
                break;
            case Jumpstate.Casting:
                if (!groundDetector.isDetected)
                    jumpState++;
                else if (jumpTimer < 0)
                    ChagePlayerState(PlayerState.Idle);
                jumpTimer -= Time.deltaTime;
               

                
                break;
            case Jumpstate.OnAction:
                if (rb.velocity.y < 0)
                    jumpState++;
                break;
            default:
                break;
        }
    }
        private void UpdateFallState()
        {
            switch (fallState)
            {
                case FallState.Idle:
                    break;
                case FallState.Prepare:
                animator.Play("Fall");
                fallState++;
                    break;
                case FallState.Casting:
                   fallState++;
                    
                    break;
                case FallState.OnAction:   
                    if (groundDetector.isDetected) 
                        fallState++;
                    break;
                case FallState.Finish:
                    ChagePlayerState(PlayerState.Idle);
                    break;
                 default:
                    break;
            }
        }

    

    

    
       

        

        
  
}





public enum PlayerState
{
       Idle,
       Run,
       Jump,
       Fall,
}
public enum Jumpstate
{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}
public enum FallState
{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}


