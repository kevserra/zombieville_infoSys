using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPt;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPt = pointB.transform;
        anim.SetBool("isWalking", true);
    }

    void Update()
    {
        Vector2 point = currentPt.position - transform.position;
        if (currentPt == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPt.position) < 10f && currentPt == pointB.transform)
        {
            FlipEnemy();
            currentPt = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPt.position) < 10f && currentPt == pointA.transform)
        {
            FlipEnemy();
            currentPt = pointB.transform;
        }
    }

    private void FlipEnemy()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(pointA.transform.position, 3f);
    //    Gizmos.DrawWireSphere(pointB.transform.position, 3f);
    //    Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    //}

}
