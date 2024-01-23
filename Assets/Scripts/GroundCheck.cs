using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool ground = false;
    public bool isGround()
    {
        return ground;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            ground = true;
            GameObject.Find("Player").GetComponent<Animator>().SetBool("Jump",false);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            ground=false;
        }
    }
}
