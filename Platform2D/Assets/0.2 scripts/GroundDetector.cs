using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isDetected
    {
        get
        {
            return dedtectedGround != null ? true : false;
        }
    }

    public Collider2D detectedGround;
    public Collider2D dete
    public LayerMask groundLayer;
    

    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private Vector2 size;
    private Vector2 center;

    private void OnDrawGizmos()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        size.x = col.size.x / 2;
        size.y = 0.005f;

        center.x = rb.position.x + col.offset.x;
        center.y = rb.position.y + col.offset.y - col.size.y / 2 - size.y;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(center.x, center.y, 0),
                            new Vector3(size.x, size.y, 0));

    }

    private void Update()
    {
        center.x = rb.position.x + col.offset.x;
        center.y = rb.position.y + col.offset.y - col.size.y / 2 - size.y;
        dedtectedGround = Physics2D.OverlapBox(center,size,0,groundLayer);
        if (detectedGround != null)
            lastGround = detectedGround;

    }
    public void ignoreLastGroundUntillPassedIt()
    {
        ignoringGround = lastGround;
        if(ignoringGround ! = null)
        StartCoroutine(E_IgnoreGroundUntillPassedIt());
    }
    
    IEnumerator E_IgnoreGroundUntillPassedIt(Collider2D groundCol)
    {
        Physics2D.IgnoreCollision(col,groundCol , true);
        float passingGroundColCenter = groundCol.transform.position.y + groundCol.offset.y;
        float groundColSizeY = groundCol.size

        //  플래이어가 해당 그라운드를 지나가기 시작하는지 체크
        yield return new WaitUntil(() =>
        {
            return rb.position.y + col. offset.y - col.size.y / 2 < passingGroundColCenter;
        }
        );
        // 플래이어 해당 그라운드를 완전히 자나갔는지 체크
        yield return new WaitUntil(() =>
        {
            bool isPassed = false;

            if(groundCol != null)
            {
                // 지형이 이동할시를 대비하여 위치를 계속 갱신함
                passingGroundColCenter = groundCol.transform.position.y + groundCol.offset.y;

                // 플래이어가 지형을 통과했는지 체크
                // 1.플레이어가 떨어지면서 지형통과
                // 2. 플레이어가 올라가면서 지형통과
                if (rb.position.y + col.offset.y + col.size.y /2 < passingGroundColCenter - size.y)
                    ((rb.position.y + col.offset.y - col.size.y / 2 < passingGroundColCenter - size.y)
            }
        });
        
    }

}

