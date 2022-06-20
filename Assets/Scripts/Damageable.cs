using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damageable : MonoBehaviour
{
   [SerializeField] float maxHealth = 100f;
   float currentHealth; 

    [SerializeField] GameObject hitEffect;
    private PlayerMotor playermotor; 
    
    void Start()
    {
        playermotor = GameObject.FindWithTag("Player").GetComponent<PlayerMotor>(); 
    }

    private void Awake()
   {
       currentHealth = maxHealth;
       

    } 

    

   public void TakeDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
   {
       Instantiate(hitEffect, hitPos, Quaternion.LookRotation(hitNormal));
       currentHealth -= damage; 
       print("hit"); 
       if (currentHealth <= 0)
       {
           Die(); 
       }
   }

   void Die()
   {
       print(name + " was destroyed");
       Destroy(gameObject);
        playermotor.UpdateScore(5); 
        
    }

    

}
