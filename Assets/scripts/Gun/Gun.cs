using UnityEngine;

public class Gun : MonoBehaviour
{
    // ===== variables =====
    public float damage = 10f;
    public float range = 100f;
    public float charge = 100f;
    public float fireRate = 0.25f;
    float canFire = 0.25f;

    public Camera playerCamera;
    public AudioSource pewpew;
    public GameObject laserProjectile;

    // just a neat vector var so I don't have to write transform.position everytime I wanna know the guns position.
    Vector3 currentPos;
    Vector3 defaultPos;
    Vector3 randomPos;

    private void Start()
    {
        //defaultPos = transform.localPosition;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // some debugging printing
        //print($"Gun charge: {charge}");
        if (Input.GetButton("Fire1") && Time.time > canFire && charge >= 4f)
        {
            Shoot();
            canFire = Time.time + fireRate;
            //randomPos = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            //this.gameObject.transform.localPosition += randomPos * Time.deltaTime;
        }

        // we can only recharge the gun if we're not holding down our trigger!
        if(!Input.GetButton("Fire1") &&  charge < 100f)
        {
            charge += 10f * Time.deltaTime;
             if(charge > 100f)
            {
                charge = 100f;
                //transform.position -= defaultPos * Time.deltaTime;
            }
        }
        
    }


    void Shoot()
    {
        pewpew.Play();
        charge -= 4f;
        // we spawn our laser beam and call its init function!!
        LaserProjectile a = Instantiate(laserProjectile, currentPos, transform.rotation * Quaternion.Euler(90,0,0)).GetComponent<LaserProjectile>();
        a.Init(this);

    }
}
