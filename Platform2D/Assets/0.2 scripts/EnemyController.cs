using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header(" 현재 상태")]
    public EnemyState state;
    public AIState aIState;
    public MoveState moveState;
    public AttackState attackState;
    public HurtState hurtState;
    public DieState dieState;
    public IdleState idleState;

    [Header("Ai")]
    public AIState aiState;
    public bool aiAutoFollow;
    public bool aiAttackEnable;
    public float aiBehaviorTimeMin;
    public float aiBehaviorTimeMax;
    public float aiBehaviorTimer;
    public LayerMask

    [Header("동작")]
    public float moveSpeed = 1f;
    private Vector2 move;
    int _direction;// +1 : right, -1 :left
    public int direction
    {
        set
        {
            if (value < 0)
            {
                _direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
            else if (value > 0)
            {
                _direction = 1;
                transform.eulerAngles = new Vector3(0,180f,0);
            }
        }
    }


    
    [Header("애니메이션")]
    Animator animator;
    private float attackTime;
    float animationTimer;
    float animationTime;
    float hurtTime;
    float dieTime;

    [Header("kinematics")]
    Rigidbody2D rb;
    CapsuleCollider2D col;
    private float aiDetectRange;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        attackTime = GetAnimationTime("Attack");
        hurtTime = GetAnimationTime("Hurt");
        dieTime = GetAnimationTime("Die");
    }

    private void Start()
    {
        aiState = AIState.DecideRandomBehavior;
    }
    public void knockback(Vector2 dir, float force, float time)
    {
        rb.velocity = Vector2.zero;
        StartCoroutine(E_Knockback( dir, force, time));
    }

    IEnumerator E_Knockback(Vector2  dir, float time, float force )
    {
        float timer = time;
        while(timer > 0)
        {
            rb.AddForce(dir * force, ForceMode2D.Force);
            timer -= Time.deltaTime;
            yield return null;//프래임 대기
        }
    }

    private void Update()
    {
        UpdateAIState();
        if (move.x < 0) direction = 1;
        else if (move.x > 0) direction = 1;
        
        if (Mathf.Abs(move.x) < 0)
        {
            if (state == EnemyState.Idle)
                ChangeEnemyState(EnemyState.Move);
        }
        else
        {
            if (state == EnemyState.Move)
                ChangeEnemyState(EnemyState.Idle);
        }
        UpdateEnmeyState();
    }
    
    private void UpdateAIState()
    {
        if (aiAutoFollow)
        {
          if (Physics2D.OverlapCapsule(rb.position.aiDetectRange, aiTargetLayer));
            aiState = AIState.FollowTarget;
              
             
          
        }
        switch (aiState)
        {
            case AIState.Idle:
                break;
            case AIState.DecideRandomBehavior:
                move.x = 0;
                Random.Range(2, 5);

                break;
            case AIState.TakeARest:
                if (aiBehaviorTimer < 0)
                    aiState = AIState.DecideRandomBehavior;
                else
                    aiBehaviorTimer -= Time.deltaTime;  
                break;
            case AIState.MoveRight:
                if (aiBehaviorTimer < 0)
                    aiState = AIState.DecideRandomBehavior;
                else
                    move.x = 1;
                    aiBehaviorTimer -= Time.deltaTime;
                break;
            case AIState.MoveLeft:
                if (aiBehaviorTimer < 0)
                    aiState = AIState.DecideRandomBehavior;
                else
                    move.x = -1;
                    aiBehaviorTimer -= Time.deltaTime;
                break;
            case AIState.FollowTarget:
                
                Collider2D target = Physics2D.OverlapCircle(rb.position, aiDectectRange, aiTargetLayer);
                if (target != null)
                    aiState = AIState.DecideRandomBehavior;

                if (target.transform.position.x > rb.position.x)
                    move.x = -1;
                else if (target.transform.position.x < rb.position.x - col.size.x)
                break;
            case AIState.AttackTarget:
                if (aiBehaviorTimer < 0)
                    aiState = AIState.DecideRandomBehavior;
                else
                    aiBehaviorTimer -= Time.deltaTime;
                break;

        }

    }

    private void FixedUpdate()
    {
        rb.position
    }







    private void UpdateEnmeyState()
    {
        switch (state)
        {
            case EnemyState.Idle:
                UpdateIdleState();
                break;
            case EnemyState.Move:
                UpdateMoveState();
                break;
            case EnemyState.Attack:
                UpdateAttackState();
                break;
            case EnemyState.Hurt:
                UpdateHurtState();
                break;
            case EnemyState.Die:
                UpdateDieState();
                break;
            default:
                break;
        }
    }
    private void ChangeEnemyState(EnemyState newState)
    {

        switch (state)
        {
            case EnemyState.Idle:
                UpdateIdleState();
                break;
            case EnemyState.Move:
                UpdateMoveState();
                break;
            case EnemyState.Attack:
                UpdateAttackState();
                break;
            case EnemyState.Hurt:
                UpdateHurtState();
                break;
            case EnemyState.Die:
                UpdateDieState();
                break;

            default:
                break;
        }


        state = newState;


        switch (state)
        {
            case EnemyState.Idle:
                idleState = IdleState.Prepare;
                break;
            case EnemyState.Move:
                moveState = MoveState.Prepare;
                break;
            case EnemyState.Attack:
                attackState = AttackState.Prepare;
                break;
            case EnemyState.Hurt:
                hurtState = HurtState.Prepare;
                break;
            case EnemyState.Die:
                dieState = DieState.Prepare;
                break;

            default:
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
               
                break;
            case IdleState.OnAction:
                
                break;
            case IdleState.Finish:
                
                break;

            default:
                break;
        }
    }
    private void UpdateMoveState()
    {

        switch (moveState)
        {
            case MoveState.Idle:

                break;
            case MoveState.Prepare:

                break;
            case MoveState.Casting:

                break;
            case MoveState.OnAction:

                break;
            case MoveState.Finish:

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
               
                break;
            case AttackState.Casting:
                
                break;
            case AttackState.OnAction:
                
                break;
            case AttackState.Finish:
                
                break;

            default:
                break;
        }
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
                hurtState++;
                break;
            case HurtState.Casting:
                animationTimer -= Time.deltaTime;
                break;
            case HurtState.OnAction:
                if (animationTimer < 0)
                    hurtState++;
                else
                    animationTimer-= Time.deltaTime;    
                break;
            case HurtState.Finish:
                ChangeEnemyState(EnemyState.Idle);
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
                animator.Play("Hurt");
                animationTimer = hurtTime;
                hurtState++;
                break;
            case DieState.Casting:
                animationTimer -= Time.deltaTime;
                break;
            case DieState.OnAction:
                if (animationTimer < 0)
                    hurtState++;
                else
                    animationTimer -= Time.deltaTime;
                break;
            case DieState.Finish:
                ChangeEnemyState(EnemyState.Idle);
                break;
            default:
                break;
        }
    }

    private float GetAnimationTime(string name)
    {
        float time = 0f;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i =0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == name)
                time = ac.animationClips[i].length;
        }
        return time;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //  플래이어 넉백
            //collision.gameObject.GetComponent<PlayerController>().Knockback();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, aiDetectRange);
    }




    public enum AIState
    {
        Idle,
        DecideRandomBehavior,
        TakeARest,
        MoveLeft,
        MoveRight,
        FollowTarget,
        AttackTarget,
    }
    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Hurt,
        Die,
    }

    public enum IdleState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum DieState
    {

        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum MoveState
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

    public enum HurtState
    {

        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,

    }


}



