using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIElements : MonoBehaviour
{
    //====== UI Elements ======
 
    public Text gunCharge;
    //====== Stuff we wanna reference ======
    Gun gunInfo;
   
    // Start is called before the first frame update
    void Start()
    {
        gunInfo = FindObjectOfType<Gun>();
    
    }
    // Update is called once per frame
    void Update()
    {
        GunChargeUpdate();
    
    }


   

    // updates the ammo count with the charge float in Gun
    void GunChargeUpdate()
    {

        gunCharge.text = $"Gun charge: {(int) gunInfo.charge}%";
    }
}
