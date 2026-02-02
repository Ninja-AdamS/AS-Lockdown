using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UFPPC;

public class AnimController : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 1f;
    public int Prisonerhealth;
    public Transform player;
    public float followRange = 10f;
    public float attackRange = 1f;
    public float moveSpeed = 20f;
    public bool dead;
    public GameObject Prisoner;
    private bool isAttacking = false;
    public randItem rndItemS;
    public PlayerScript PlayerS;





    void FollowPlayer()
    {
        if (!dead)
        {
    
            Vector3 direction = (player.transform.position - transform.position);
            direction.y = 0;

            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
            
            if (direction != Vector3.zero)
            {
                transform.forward = direction.normalized;
            }
        }
    }

    System.Collections.IEnumerator Attack()
    {
        isAttacking = true;
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            if (dead == false){
            animator.SetTrigger("Punch");
            PlayerS.PlayerAttacked();
            yield return new WaitForSeconds(2f);
            isAttacking = false;
            }
        }
    }
    


    void Start()
    {
        dead = false;
    }

    System.Collections.IEnumerator Shift()
    {
        if (dead == true)
        {
            yield return new WaitForSeconds(4f);
            rndItemS.SpawnItem();
            yield return new WaitForSeconds(6.7f);
            Destroy(Prisoner);
        }
    }

    void Update()
    {
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            if (!isAttacking)
            {
                StartCoroutine(Attack());
            }
        }
        else if (distance <= followRange)
        {
            FollowPlayer();
        }
        
    }

    public void Die()
    {
        dead = true;
        Animator animator = GetComponent<Animator>();
        if (animator != null) 
        {
            animator.SetTrigger("Sleep");
            StartCoroutine(Shift());
        } 
    }
}
