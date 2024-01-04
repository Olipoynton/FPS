using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cam;
    
    float timeSinceLastShot;

    public ParticleSystem muzzleflash;

    private void Start()
    {
        playerShoot.shootInput += Shoot;
        playerShoot.reloadInput += StartReload;
    }

    private void OnDisable() => gunData.reloading = false;
    
        
    
    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }
    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
       
        
        if (gunData.currentAmmo > 0)
        { 
            muzzleflash.Play();


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


            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private void OnGunShot()
    {
       
    }
}
