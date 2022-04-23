using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
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
    public IdleState idleState;
    public JumpState jumpState;
    public FallState fallState;
    public RunState runState;
    public AttackState attackState;
    public DashAttack dashattackState;
    public HurtState hurtState;
    public DieState dieState;

    [Header("에니메이션")]
    private Animator animator;
    private float animationTimer;
    private float attacktime;
    private float jumpCastingTime = 0.1f;
    private float jumpCastingTimer;

    [Header("Physics")]
    public Vector2 attackBoxCastCenter;
    public Vector2 attackBoxCastSIze;
    public float attackKnockbackForce;
    public float attackKnockbackTime;
    RaycastHit2D[] hits;

    public LayerMask enemyLayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundDetector = GetComponent<GroundDetector>();
        attacktime = GetAnimationTime("Attack");
        dashattackTime = GetAnimationTime("DashAttack");
        hurtTime = GetAnimationTime("Hurt");
        dieState = GetAnimationTime("Die");

    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        // 방향전환
        if (h < 0) direction = -1;
        else if (h > 0) direction = 1;





        if (Mathf.Abs(h) > moveInputOffset)
        {

            move.x = h;
            if (state == PlayerState.Idle)
                ChangePlayerState(PlayerState.Run);
        }

        else
        {
            move.x = 0;
            if (state == PlayerState.Run)
                ChangePlayerState(PlayerState.Idle);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (groundDetector.isDetected &&
                state != PlayerState.Jump &&
                state != PlayerState.Fall)
            {
                ChangePlayerState(PlayerState.Jump);
            }
        }
        // 공격키
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (state != PlayerState.Attack) ;
            ChangePlayerState(PlayerState.Attack);
        }
        // 대시 공격기
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (state != PlayerState.Attack &&
                state != PlayerState.DashAttack)
                ChangePlayerState(PlayerState.DashAttack);
        }

        UpdatePlayerstate();

    }

    private void FixedUpdate()
    {
        rb.position += new Vector2(move.x * moveSpeed, move.y) * Time.fixedDeltaTime;
    }
    public void ChangePlayerState(PlayerState newState)
    {
        if (state == newState) return;

        //이전 상태 하위 머신 초기화
        switch (state)
        {
            case PlayerState.Idle:
                idleState = IdleState.Prepare;
                break;
            case PlayerState.Run:
                runState = RunState.Prepare;
                break;
            case PlayerState.Jump:
                jumpState = JumpState.Idle;
                break;
            case PlayerState.Fall:
                fallState = FallState.Idle;

                break;
            case PlayerState.Attack:
                attackState = AttackState.Idle;
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
                jumpState = JumpState.Prepare;
                break;
            case PlayerState.Fall:
                fallState = FallState.Prepare;

                break;
            case PlayerState.DashAttack:
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
                UpdateIdleState();
                break;
            case PlayerState.Run:
                UpdateRunState();
                break;
            case PlayerState.Jump:
                UpdateJumpstate();
                break;
            case PlayerState.Fall:
                UpdateFallState();
                break;
            case PlayerState.Attack:
                UpdateAttackState();
                break;
            case PlayerState.DashAttack:
                UpdateDashAttackState();
                break;
            default:
                break;
            case PlayerState.Hurt:
                UpdateHurtState();
                break;
            case PlayerState.Die:
                UpdateDieState();
                break;
        }
    }
    private void UpdateIdleState()
    {

        switch (idleState)
        {
            case IdleState.Idle:

                break;
            case IdleState.Prepare:

                break;
            case IdleState.Casting:
                UpdateJumpstate();
                break;
            case IdleState.Finish:
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
            case JumpState.Idle:
                break;
            case JumpState.Prepare:
                animator.Play("Jump");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCastingTimer = jumpCastingTime;
                jumpState++;
                break;
            case JumpState.Casting:
                if (!groundDetector.isDetected)
                    jumpState++;
                else if (jumpCastingTimer < 0)
                    ChangePlayerState(PlayerState.Idle);
                jumpCastingTimer -= Time.deltaTime;
                break;

            case JumpState.OnAction:
                if (rb.velocity.y < 0)
                    jumpState++;
                break;
            case JumpState.Finish:
                ChangePlayerState(PlayerState.Fall);
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
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                break;
        }
    }
    private void UpdateRunState()
    {

        switch (runState)
        {
            case RunState.Idle:

                break;
            case RunState.Prepare:

                break;
            case RunState.Casting:
                UpdateJumpstate();
                break;
            case RunState.OnAction:
                UpdateFallState();
                break;
            case RunState.Finish:
                break;

            default:
                break;
        }
    }
    private void UpdateAttackState()
    {
        switch (attackState)
        {
            case AttackState.Idle:
                break;
            case AttackState.Prepare:
                animator.Play("Attack");
                animationTimer = attacktime;
                attackState++;
                break;
            case AttackState.Casting:
                if (animationTimer < attacktime / 2)
                {
                    Vector2 tmpCenter = attackBoxCastCenter + rb.position;

                    RaycastHit2D hit = Physics2D.BoxCast(attackBoxCastCenter + rb.position,
                                                         attackBoxCastSIze,
                                                         0,
                                                        Vector2.zero,
                                                        0,
                                                        enemyLayer);
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        hit.collider.GetComponent<EnemyController>().knockback(new Vector2(direction, 0), attackKnockbackForce, attackKnockbackTime);
                    }

                    attackState++;

                }
                else
                    animationTimer -= Time.deltaTime;

                break;
            case AttackState.OnAction:
                if (animationTimer < 0)
                {
                    attackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case AttackState.Finish:
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                break;
        }



    }
    private void UpdateDashAttackState()
    {

    }

    private float GetAnimationTime(string name)
    {
        float time = 0f;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == name)
                time = ac.animationClips[i].length;
        }
        return time;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 tmpCenter = attackBoxCastCenter + rb.position;
        tmpCenter = new Vector2(attackBoxCastCenter.x * direction, attackBoxCastCenter.y) + rb.position;
        Gizmos.DrawWireCube(tmpCenter, attackBoxCastSIze);

    }
     
    private void UpdateHurtState()
    {

        switch (hurtState)
        {
            case HurtState.Idle:

                break;
            case HurtState.Prepare:
                animator.Play("Hurt");
                animationTimer = hurtTime;
                break;
            case HurtState.Casting:
                UpdateJumpstate();
                break;
            case HurtState.OnAction:
                UpdateFallState();
                break;
            case HurtState.Finish:
                break;

            default:
                break;
        }
    }

    private void UpdateDieState()
    {

        switch (dieState)
        {
            case DieState.Idle:

                break;
            case DieState.Prepare:
                animator.Play("Die");
                animationTimer = dieTime;
                break;
            case DieState.Casting:
                UpdateJumpstate();
                break;
            case DieState.OnAction:
                UpdateFallState();
                break;
            case DieState.Finish:
                break;

            default:
                break;
        }
    }

    

}

public enum DieState
{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,

}

public enum HurtState
{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}


public enum PlayerState
{
     Idle,
     Run,
     Jump,
     Fall,
    Attack,
    DashAttack,
}
public enum JumpState
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
public enum IdleState
{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}
public enum RunState
{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}
public enum AttackState
{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}
public enum DashAttack
{

    Idle,
    Run,
    Jump,
    Fall,
    Attack,
    DashAttack,
}