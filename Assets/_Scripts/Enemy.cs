using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public int health = 100;
    private Animator anim;
    public float delayDestruc = 0.1f;
    private bool isDeadd = false;
    private Rigidbody2D rb;

    public int damageAmount = 25;

    public Transform player;
    public float atkDistance = 3f;
    public bool isAttacking = false;

    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackSpeed <= canAttack)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    AudioManager.Instance.PlaySFX("Hit");
                    playerHealth.TakeDamage(damageAmount);
                }
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }






    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameManagerScript.instance.EnemyKilled();
            AudioManager.Instance.PlayZ("DyingZ");
            anim.SetTrigger("isDead");
            isDeadd = true;
            FreezeXPosition();
            StartCoroutine(DestroyAfterAnimation());
            //Die();          
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
    private void FreezeXPosition()
    {
        // Freeze X movement by setting constraints
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    void Die()
    {    
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= atkDistance && !isAttacking)
        {
            anim.SetTrigger("Attack");
            isAttacking = true;
        }
        else if (distanceToPlayer > atkDistance && isAttacking)
        {
            isAttacking = false;
        }
    }
}
