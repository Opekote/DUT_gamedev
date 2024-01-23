using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator anima;
    GameObject player;
    public Transform attackPoint;
    public float attackRate = 2f;
    LayerMask Players;
    public bool attackPlayer = false;
    int l =- 2;
    public bool playerYes = true;
    public int speed;
    public bool PlayerR;
    public int adg1 = 20;
    public int adg2 = 30;
    public int adg3 = 50;
    int pr; // flip side
    float PLY; //Player Y position
    public float minplY; //Checking by Y when player is beneath
    public float maxplY; // Checking by Y when player is above
    int currentHealth = 2000;
    SpriteRenderer sr; // sprite flip
    public Image hp; 
    public GameObject HP;
    int attakStop = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        PlayerR = true;
        pr = 1;
        speed = 2;
        Players = LayerMask.GetMask("Player");
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        hp.fillAmount = (float)currentHealth / 2000;
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
        float rpe = baX - plX;

        if(rpe*-1<=2 && PlayerR == true && attakStop ==0)
        {

          playerYes = false;
          speed = 1;
          anima.SetBool("go",true);
          HP.SetActive(true);
          
        }
        else if (rpe*-1>=-2 && PlayerR == false  && attakStop ==0)
        {
          playerYes = false;
          speed = -1;
          anima.SetBool("go",true);
          HP.SetActive(true);
        }
        
        if(PlayerR == true){
        if(rpe*-1>=2 || rpe*-1<=1)
      {
        speed = 0;
        anima.SetBool("go",false);
        playerYes = true;
      }
            }
            if(PlayerR == false)
            {
            if(rpe*-1<=-2 || rpe*-1>=-1 )
        {
        speed = 0;
        anima.SetBool("go",false);
        playerYes = true;
        }
             }
        }
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    anima.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anima.SetBool("Die", true);
       var rb = GetComponent<Rigidbody2D>();
       rb.constraints = RigidbodyConstraints2D.FreezeAll; 

        GetComponent <Collider2D>().enabled = false;
        this.enabled = false;
        
        if (currentHealth <= 0)
        {
            HP.SetActive(false);
        } 
    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        if(coll.name == "Player" )
        {
          attak_BAN();  
          attackPlayer = true;
        }
    }

    public void PlayerA()
    {
        if (attackPlayer == true)
        {
            attak_BAN();
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
         if(coll.name == "Player" )
        {
          attackPlayer = false;
        }
    }
    public void attak_BAN()
    {
        int move = Random.Range(1,5);
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
            case 4: 
            anima.SetTrigger("attak_4");
            break;
        }
    }

    void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
            return;

            Gizmos.DrawWireSphere(attackPoint.position,attackRate);
        }

    public void Attack()
    {

    Collider2D[] allPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRate, Players);

    foreach (Collider2D player in allPlayers)
     {
    if (player.tag=="Player")
        {
            player.GetComponent<Player1>().TakeDamage(adg1);
        }
      }
    }
   

public void NO_YOU_TRUE_DED()
{
    if (currentHealth <=0)
    {
        anima.SetBool ("NO_YOU_TRUE_DED",true);
    } 
}
}
