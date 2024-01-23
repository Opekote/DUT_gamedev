using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour

{
    private float lengh, startpos;
    public GameObject camers;
    public float parallaxEffects;

 void Update()
    {
        float dist = (camers.transform.position.x * parallaxEffects);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    } 
}


