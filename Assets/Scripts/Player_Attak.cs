using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attak : MonoBehaviour
{

public Transform AttackPoint;
public LayerMask enemyLeyers;
public float attackRange = 0.5f;

public int easyDamage = 20;
public int mediumDamage = 30;
public int hardDamage = 50;
public float attackRate = 2f;


public void Attack()
{
  
    //capsule collider near player (for making damage)
  Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLeyers);
    // checking type of enemy
  foreach(Collider2D enemy in hitEnemies)
      {
        if (enemy.tag == "Boss")
        {
          enemy.GetComponent<Boss>().TakeDamage(easyDamage);
        }
        else 
        {
          enemy.GetComponent<Bandit_1>().TakeDamage(easyDamage);
        }
      }

}
public void Attack2()
{
  
  //capsule collider near player (for making damage)
  Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLeyers);
  // checking type of enemy
  foreach(Collider2D enemy in hitEnemies)
      {
        if (enemy.tag == "Boss")
        {
          enemy.GetComponent<Boss>().TakeDamage(mediumDamage);
        }
        else 
        {
          enemy.GetComponent<Bandit_1>().TakeDamage(mediumDamage);
        }
      }

}

public void Attack3()
{
  
  //capsule collider near player (for making damage)
  Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLeyers);
  // checking type of enemy
  foreach(Collider2D enemy in hitEnemies)
      {
       if (enemy.tag == "Boss")
        {
          enemy.GetComponent<Boss>().TakeDamage(hardDamage);
        }
        else 
        {
          enemy.GetComponent<Bandit_1>().TakeDamage(hardDamage);
        }
      }

}
        void OnDrawGizmosSelected()
        {
            if (AttackPoint == null)
            return;

            Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        }

}
