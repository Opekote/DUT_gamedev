using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    public float upperBorder;
    public float downBorder;
    public Rigidbody2D rb2d;
    private int dir = 0;
    bool upStop=false; //elevator stands on top
    bool downStop=true; //elevator stands at floor
    bool goUp=false; //elevator goes up
    bool goDown=false; //elevator goes down

    private void Update() 
    {
        rb2d.velocity = Vector2.up*dir;

        if(goUp && rb2d.position.y>=upperBorder) {//-0.7
            goUp = false;
            upStop = true;
            dir=0;
        }
        if(goDown && rb2d.position.y<=downBorder) {//-2.6
            goDown = false;
            downStop = true;
            dir=0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (downStop) {
            downStop=false;
            goUp = true;
            dir=1;
        } else if(upStop) {
            upStop=false;
            goDown=true;
            dir=-1;
        } else if(goDown) {
            goDown=false;
            goUp=true;
            dir=1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
     {
        if(upStop) {
            upStop=false;
            goDown=true;
            dir=-1;
        }
        if (goUp) {
            goDown=true;
            goUp=false;
            dir=-1;
        }
    } 
}
