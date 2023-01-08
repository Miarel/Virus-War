using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static event System.Action<Virus> TouchedVirus;
    private Transform target;
    private Virus targetVirus;
    [SerializeField] private float speed;

    private void OnEnable() 
    {
        DefendedCell.BulletSpawned += SetTarget;
    }

    private void Update() 
    {
        Move();
    }

    public void SetTarget(Transform enemy, Virus virus)
    {
        targetVirus = virus;
        target = enemy;
    }

    private void Move()
    {
        if(target != null)
        {
            Debug.Log(Vector2.Distance(transform.position, target.position));
            if(Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                Destroy(gameObject);
                TouchedVirus?.Invoke(targetVirus);
            }
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable() 
    {
        DefendedCell.BulletSpawned -= SetTarget;
    }
}
