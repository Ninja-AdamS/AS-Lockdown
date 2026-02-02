using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballAnimator : MonoBehaviour
{
    public void PlayAnimB()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Basketball");
        }
    }
}   
