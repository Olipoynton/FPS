using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    [SerializeField] public GunData gunData;
    [SerializeField] public playerHealth Playerhealth;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ammo"))
        {
            Destroy(other.gameObject);

        if (gunData.currentAmmo >= 0)
        {
            gunData.currentAmmo += gunData.magSize;
        }

        }

       

        if (other.CompareTag("Respawn"))
        {
            gunData.currentAmmo = 0;
        }


    }

    void Start()
    {
        if (gunData.currentAmmo > 0)
        {
            gunData.currentAmmo = 0;
        }
    }

    

}
