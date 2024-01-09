using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnCollision : MonoBehaviour
{
    [SerializeField] public GunData gunData;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            gunData.currentAmmo = gunData.magSize;
        }
    }
}
