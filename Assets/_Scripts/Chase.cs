using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public Transform playerTransform;
    private Rigidbody2D rb;
    private Animator anim;
    public float specificDistance = 0.5f;
    public Enemy enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        enemy = GetComponent<Enemy>();
        anim.SetBool("isWalking", true);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        //Vector3 direction = player.transform.position - transform.position;

        if (distance <= specificDistance)
        {
            anim.SetBool("isIdle", true);
        }
        else
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(-6, 6, 1);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(6, 6, 1);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        //transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //if (enemy.isAttacking)
        //{
        //    anim.SetBool("isWalking", false);
        //}
    }
}
