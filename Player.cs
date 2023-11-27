using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float attackRadius = 5.0f;
   public LayerMask enemyLayer;
   public Animator animator;
   public List<AnimationClip> comboAnimations;

   void Update()
   {
       if (Input.GetButtonDown("Fire1"))
       {
           Attack();
       }
   }

   void Attack()
   {
       Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

       foreach (Collider2D enemy in enemies)
       {
           // Attack the enemy and play a random combo animation
           // This will depend on how your enemy objects and animations are set up
           // For example:
           // enemy.GetComponent<Enemy>().TakeDamage(10);
           // animator.Play(comboAnimations[Random.Range(0, comboAnimations.Count)]);
       }
   }
}
