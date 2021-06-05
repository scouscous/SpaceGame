using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public Collider hitBox;
    // this shit won't work!!!!!!!!
    public ParticleSystem laserHit;
    

    private void OnTriggerEnter(Collider other)
    {
        print("Collided!");
       // SpawnParticles();
        Destroy(this.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void SpawnParticles()
    {
      laserHit = laserHit.GetComponent<ParticleSystem>();
      Instantiate(laserHit, transform.position, transform.rotation);

    }

}
