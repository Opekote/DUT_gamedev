using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D body;
    private float speed = 1f;
    public float JumpForce = 210f;
    public Animator animator;
    public bool isGrounded;
    public int maxHealth = 100; 
    public int currentHealth = 100;
    int animationNumber = 0;
    public bool notJump = true;
    GameObject HP;
    public Image hp;
    bool jump;
    
    public GameObject GameOverMenuUI;


void Start()
{
    animator.SetBool("Jamp",true);
     currentHealth = maxHealth;
     Cursor.visible = false;

}
    void Update()
    {
        hp.fillAmount = (float)currentHealth / 100;
        if (currentHealth <= 5)
        {
            Die();
            animator.SetBool("dead",true);
        }
        
        if (Input.GetKeyDown (KeyCode.Space)&& jump == true) 
        {
            animator.SetTrigger("Jump");
      
        }
   
         float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); 

        //set parameters of animation 
        animator.SetBool("Run",horizontalInput != 0);

        // code to flip chracter
        if (horizontalInput > 0.1f)
        transform.localScale = Vector3.one;
        else if (horizontalInput < -0.1f)
        transform.localScale = new Vector3 (-1,1,1);
        Debug.Log(JumpForce);
        

//bindings to trigger animation
     if(Input.GetKeyDown(KeyCode.I) ){
    animator.SetTrigger("Atak1");
    animationNumber = 1;
}
    if(Input.GetKeyDown(KeyCode.O)){
    animator.SetTrigger("Atak2");
    animationNumber = 2;
}
   if(Input.GetKeyDown(KeyCode.P)){
   animator.SetTrigger("Atak3");
}
    if(animationNumber == 1 && Input.GetKeyDown(KeyCode.O)){
   animator.SetTrigger("AtakKombo");
   animationNumber = 2;
}
    if(animationNumber == 2 && Input.GetKeyDown(KeyCode.P)){
    animator.SetTrigger("AtakKombo");
}

    }
public void Jump()
{
    GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 500,0));
}
    //block of animation change
  public void KomboNet() 
  {
      animationNumber = 0;
  }

 private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ground"){
            jump = true;
            animator.SetBool("Jamp", true);
        }
    }
    void OnCollisionExit2D(Collision2D coll){
        if(coll.gameObject.tag == "Ground"){
            jump = false;
            animator.SetBool("Jamp", false);
        }
    } 
    
public void  SetHealth (int bonusHealth)
{
    currentHealth += bonusHealth;
    
    if  (currentHealth > maxHealth)
    {
        currentHealth = maxHealth;
    }
}

    //taking damage

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        animator.SetTrigger("hurt");

    }
    
    // Die animation 

    public void Die()
    {
        // Debug.Log("Enemy died!");
        animator.SetTrigger("die");
       var rb = GetComponent<Rigidbody2D>();
       rb.constraints = RigidbodyConstraints2D.FreezeAll; 

        GetComponent <Collider2D>().enabled = false;
        this.enabled = false;  
    }
    public void End()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioSource cameraAudioSource = Camera.main.GetComponent<AudioSource>();
        if (cameraAudioSource != null)
        {
            cameraAudioSource.Stop();
        }
        CameraController.GameIsPaused = true;
        // SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }
}