using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bandit_1 : MonoBehaviour
{    
    public Rigidbody2D rb2d;
    public Animator anima;
    GameObject player;
    public Transform attackPoint;
    public float attackRate = 2f;
    LayerMask Players;
    public int maxHealth = 100;
    int currentHealth;
    public bool attackPlayer = false;
    int l =- 2;
    public bool playerYes = true;
    float speed;
    public bool PlayerR;
    public int easyDamage = 20;
    public int mediumDamage = 30;
    public int hardDamage = 50;
    SpriteRenderer sr; // for flipping enemy
    int pr; // where enemy is looking at
    float PLY; //player Y pos
    public float minplY; //Checking by Y when player is beneath
    public float maxplY; // Checking by Y when player is above

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        PlayerR = true;
        pr = 1;
        speed = 1;
        Players = LayerMask.GetMask("Player");
        player = GameObject.FindWithTag("Player");
        currentHealth = maxHealth;
    }
    void Update()
    // change of position 
    {
        float baX = gameObject.transform.position.x;
        float plX = player.transform.position.x;
        PLY = player.transform.position.y;
        if (PLY<=maxplY && PLY>=minplY){
        if(plX < baX)
        {
            PlayerR = false;
        }
        if(plX > baX)
        {
            PlayerR = true;
        }
        if (PlayerR == false && pr == 1)
        {
            sr.flipX = true;
            pr = 2;
        }
        if (PlayerR == true && pr == 2)
        {
           sr.flipX = false;
           pr = 1;
        }
        rb2d.velocity = new Vector2(speed,0);
        //follow player + search player
        float rpe = baX - plX;
        Debug.Log (rpe*-1);
        if(rpe*-1<=2 && PlayerR == true)
        {
          playerYes = false;
          speed = 1;
          anima.SetBool("go",true);
        }
        else if (rpe*-1>=-2 && PlayerR == false)
        {
          playerYes = false;
          speed = -1;
          anima.SetBool("go",true);
        }
        //stop following player
        if(PlayerR == true){
        if(rpe*-1>=2 || rpe*-1<=0.35 )
      {
        speed = 0;
        anima.SetBool("go",false);
        playerYes = true;
      }
            }
            if(PlayerR == false)
            {
            if(rpe*-1<=-2 || rpe*-1>=-0.35 )
        {
        speed = 0;
        anima.SetBool("go",false);
        playerYes = true;
        }
             }
        }
        
    }
    
    
    // getting damage

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    anima.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
// Die animation 
    void Die()
    {
        anima.SetBool("Die", true);
       var rb = GetComponent<Rigidbody2D>();
       rb.constraints = RigidbodyConstraints2D.FreezeAll; 

        GetComponent <Collider2D>().enabled = false;
        this.enabled = false;
    }

// methoad after detecting attack
    void OnTriggerEnter2D (Collider2D coll)
    {
         
        if(coll.name == "Player" )
        {
          SelectAttack();  
          attackPlayer = true;
        }
    }

    public void PlayerA()
    {
        if (attackPlayer == true)
        {
            SelectAttack();
        }
    }
    // detect that player run away
    void OnTriggerExit2D(Collider2D coll)
    {
         if(coll.name == "Player" )
        {
          attackPlayer = false;
        }
    }
    // enemy attack selector
    public void SelectAttack()
    {
        int move = Random.Range(1,4);
        switch(move)
        {
            case 1: 
            anima.SetTrigger("attak_1");
            break;
            case 2: 
            anima.SetTrigger("attak_2");
            break;
            case 3: 
            anima.SetTrigger("attak_3");
            break;
        }
    }

    void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
            return;

            Gizmos.DrawWireSphere(attackPoint.position,attackRate);
        }

    public void Attack1()
    {

    Collider2D[] allPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRate, Players);

    foreach (Collider2D player in allPlayers)
     {
    if (player.tag=="Player")
        {
            player.GetComponent<Player1>().TakeDamage(easyDamage);
        }
      }
    }
   
public void Attack2()
    {

    Collider2D[] allPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRate, Players);

    foreach (Collider2D player in allPlayers)
             {
    if (player.tag=="Player")
        {
            player.GetComponent<Player1>().TakeDamage(mediumDamage);
        }
            }
     }

public void Attack3()
    {

    Collider2D[] allPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRate, Players);

    foreach (Collider2D player in allPlayers)
            {
    if (player.tag=="Player")
        {
            player.GetComponent<Player1>().TakeDamage(hardDamage);
        }
            }
    }
public void EnemyIsDead()
{
    if (currentHealth <=0)
    {
        anima.SetBool ("EnemyIsDead",true);
    } 
}

} 