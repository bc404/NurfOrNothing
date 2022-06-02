using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
   [SerializeField] float maxHealth = 100f;
   float currentHealth; 

   private void Awake()
   {
       currentHealth = maxHealth; 
   } 

   public void TakeDamage(float damage)
   {
       currentHealth -= damage; 
       if (currentHealth <= 0)
       {
           Die(); 
       }
   }

   void Die()
   {
       print(name + " was destroyed");
       Destroy(gameObject); 
   }
}
