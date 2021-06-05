using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    // TODO
    // add hit detection | collider or the rigidbody? rigidbody is nice to have for its velocity function.
    // make the target lower its health if it has any
    // destory this game ojbect

    public float lifetime;
    public Rigidbody rb;
    public float distanceToDestroy = 20f;
    float currentDistance;
    Vector3 currentPos;

    // we need to get the Camera's forward vector.
    // the laser beam needs to align to that vector and move along it via the projectile speed.

    public float projectileSpeed = 2000f;
    GameObject player;


  

    void Start()
    {
        rb = rb.GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        // wrap this up in it's own function?

        // so we need to update every frame to find the rigidbodies current pos, so we can find out how far away
        // it is from the player and destroy the game object when it's far away enough. Otherwise it'll just go off
        // into the distance forever.
        currentPos = new Vector3(rb.position.x, rb.position.y, rb.position.z);
        // we find the player here. I think I put it in update because if it's in start it's just find the player once
        // and never look for it again, so we'll never know if the player had moved or something.
        player = GameObject.Find("Player");
        // and calculate the distance every frame.
        currentDistance =  Vector3.Distance(currentPos, player.transform.position);

        // DEBUGGING STUFF
        //print($"Current Pos: {currentPos.x}, {currentPos.y}, {currentPos.z}");
        //print($"Current distance from player: {currentDistance}");

        // and every frame we see if the distance is greater than the float we set for the destruction to happen!
        if (currentDistance > distanceToDestroy)
        {
            Destroy(this.gameObject);
        }
    }



    // when the object is spawned by firing in Gun, we get the gun's forward vector and set the rb velocity to match it and send it off by 
    // the projectile speed.
    public void Init(Gun gun)
    {
       
       rb.velocity = (gun.transform.forward * Time.deltaTime) * projectileSpeed;
    }
}
