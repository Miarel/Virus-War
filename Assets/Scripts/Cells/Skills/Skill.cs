using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected float _cooldown;
 
    [SerializeField] protected string _name;

    [SerializeField] protected string _description;

    [SerializeField] protected float _cost;

    public abstract void Effect();
}

