using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header(" 현재 상태")]
    public EnemyState state;
    public MoveState moveState;
    public AttackState attackState;
    public HurtState hurtState;
    public DieState dieState;
    public IdleState idleState;

    [Header("애니메이션")]
    Animator animator;
    private float attackTime;
    float animationTimer;
    float animationTime;
    float hurtTime;
    float dieTime;

    [Header("kinematics")]
    Rigidbody2D rb;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        attackTime = GetAnimationTime("Attack");
        hurtTime = GetAnimationTime("Hurt");
        dieTime = GetAnimationTime("Die");
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






