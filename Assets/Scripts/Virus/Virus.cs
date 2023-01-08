using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Virus :MonoBehaviour, Damager, Mobile, Healer
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float heath;
    [SerializeField] private float price;

    public float Price { get => price;}

    private Vector3 targetPosition;
    private Cell sender;
    private void OnEnable()
    {
        Bullet.TouchedVirus += TouchedBullet;
    }

    public void Attack(Attackable target)
    {
        target.TakeDamage(sender,damage);
        Destroy(gameObject);
    }

    public void Heal(Healing healing)
    {
        healing.Heal(sender,heath);
        Destroy(gameObject);
    }

    public void MoveTo(Cell sender, Transform target)
    {
        this.sender = sender;
        targetPosition = target.position;
    }

    private void MoveToCell() 
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    private void TouchedBullet(Virus virus)
    {
        if(this == virus)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.position == targetPosition)
        {
            if (OnCheckAlly(collision.gameObject))
            {
                OnAllyTrigerBehaviour(collision.gameObject);
                return;
            }

            if (OnCheckEnemy(collision.gameObject)) 
            { 
                OnEnemyTrigerBehaviour(collision.gameObject);
                return;
            }

            if (OnCheckNeutrall(collision.gameObject))
            {
                OnNeutrallTrigerBehaviour(collision.gameObject);
                return;
            }

            Destroy(gameObject);
        }
    }

    public abstract void OnEnemyTrigerBehaviour(GameObject gameObject);
    public abstract void OnAllyTrigerBehaviour(GameObject gameObject);
    public abstract void OnNeutrallTrigerBehaviour(GameObject gameObject);

    public abstract Boolean OnCheckEnemy(GameObject gameObject);
    public abstract Boolean OnCheckAlly(GameObject gameObject);
    public abstract Boolean OnCheckNeutrall(GameObject gameObject);

    private void Update()
    {
        MoveToCell();
    }
}
