using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    [SerializeField] public GunData gunData;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shotgun ammo"))
        {
            Destroy(other.gameObject);

        }

        if (gunData.currentAmmo >= 0)
        {
            gunData.currentAmmo += gunData.magSize;
        }

    }
}
