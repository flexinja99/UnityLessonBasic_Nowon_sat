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

        //  �÷��̾ �ش� �׶��带 �������� �����ϴ��� üũ
        yield return new WaitUntil(() =>
        {
            return rb.position.y + col. offset.y - col.size.y / 2 < passingGroundColCenter;
        }
        );
        // �÷��̾� �ش� �׶��带 ������ �ڳ������� üũ
        yield return new WaitUntil(() =>
        {
            bool isPassed = false;

            if(groundCol != null)
            {
                // ������ �̵��ҽø� ����Ͽ� ��ġ�� ��� ������
                passingGroundColCenter = groundCol.transform.position.y + groundCol.offset.y;

                // �÷��̾ ������ ����ߴ��� üũ
                // 1.�÷��̾ �������鼭 �������
                // 2. �÷��̾ �ö󰡸鼭 �������
                if (rb.position.y + col.offset.y + col.size.y /2 < passingGroundColCenter - size.y)
                    ((rb.position.y + col.offset.y - col.size.y / 2 < passingGroundColCenter - size.y)
            }
        });
        
    }

}

