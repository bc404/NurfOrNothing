/* Chandler, June 2
added raycast for shooting gun
can now damage enemy with raycast mouse clicks
June 8
added rapid fire option to gun 
added reload function 
added concrete hit effect for house colliders 
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Transform cam; 

    public bool rapidFire = false; 

    [SerializeField] float range = 50f; 
    [SerializeField] float damage = 10f; 

    [SerializeField] float fireRate = 5f;
    WaitForSeconds rapidFireWait; 

    [SerializeField] int maxAmmo; 
    int currentAmmo; 

    [SerializeField] float reloadTime; 
    WaitForSeconds reloadWait; 

    [SerializeField] GameObject floorHitEffect;

    private void Awake()
    {
        cam = Camera.main.transform; 
        rapidFireWait = new WaitForSeconds(1 / fireRate); 
        reloadWait = new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo; 
    }

    public void Shoot()
    {
        currentAmmo--; 
        RaycastHit hit; 
        if (Physics.Raycast(cam.position, cam.forward, out hit, range))
        {
            if (hit.collider.GetComponent<Damageable>() != null)
            {
                hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal); 
            }
            
            else if (hit.collider.CompareTag("House") )
            {
                Debug.Log("Hit Floor"); 
                Instantiate(floorHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    public IEnumerator RapidFire()
    {
        if (CanShoot())
        {
            Shoot(); 
            if (rapidFire)
            {
                while (CanShoot())
                {
                    yield return rapidFireWait; 
                    Shoot(); 
                }
                StartCoroutine(Reload());
            }  
        } 
        else
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        if (currentAmmo == maxAmmo)
        {
            yield return null; 
        }

        print("reloading...");
        yield return reloadWait;
        currentAmmo = maxAmmo; 
        print("finished reloading"); 

    }

    bool CanShoot()
    {
        bool enoughAmmo = currentAmmo > 0; 
        return enoughAmmo; 
    }
}
