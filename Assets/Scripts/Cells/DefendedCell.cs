using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DefendedCell : MonoBehaviour
{
    public static event System.Action<Transform, Virus> BulletSpawned;

   [SerializeField] private float range;
   [SerializeField] private float cooldown;
   [SerializeField] private GameObject bullet;
   private Virus targetVirus;
   private float currentCooldown;


   private void Update() 
   {
        if(CanShoot())
        {
            SearchTarget();
        }
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
   }

   bool CanShoot()
   {
        if(currentCooldown<=0)
            return true;
        return false;
   }

   private void SearchTarget()
   {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;
        foreach(Virus virus in FindObjectsOfType<Virus>())
        {
            float currentDistance = Vector2.Distance(transform.position, virus.transform.position);

            if(currentDistance <= range && currentDistance < nearestEnemyDistance)
            {
                targetVirus = virus;
                nearestEnemy = virus.transform;
                nearestEnemyDistance = currentDistance;
            }
            if(nearestEnemy != null)
            {
                Shoot(nearestEnemy);
            }
        }
   }

   private void Shoot(Transform enemy)
   {
        currentCooldown = cooldown;
        GameObject projectile = Instantiate(bullet,gameObject.transform.position,gameObject.transform.rotation);
        BulletSpawned?.Invoke(enemy,targetVirus);
   }
}
