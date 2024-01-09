using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("references")]
    [SerializeField] public GunData gunData;
    [SerializeField] private Transform cam;
    
    float timeSinceLastShot;

    public ParticleSystem muzzleflash;
    public Text ammoDisplay;


    private void Start()
    {
        playerShoot.shootInput += Shoot;
        //playerShoot.reloadInput += StartReload;
        
    }

    private void OnDisable() => gunData.reloading = false;


   



    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
       
        
        if (gunData.currentAmmo > 0)
        { 
          


            if (CanShoot())
            {
                if (Physics.Raycast(cam.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamagable damagable = hitInfo.transform.GetComponent<IDamagable>();
                    damagable?.TakeDamage(gunData.damage);

                    Debug.Log(hitInfo.transform.name);

                    
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
                muzzleflash.Play();

            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        ammoDisplay.text = gunData.currentAmmo.ToString();
    }

    private void OnGunShot()
    {
       
    }

    
}
