using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public abstract class Cell : MonoBehaviour
{
    [SerializeField] protected float dnaCount = 0;
    [SerializeField] protected int dnaCapacity = 10;
    [SerializeField] protected float reproductionSpeed = 1;
    [SerializeField] protected TextMeshPro tmp;
    public void Start()
    {
        tmp = gameObject.GetComponentInChildren<TextMeshPro>();
    }
    public string Text
    {
        get =>tmp.text;
        set =>tmp.text=value;
    }
    
    public abstract void Update();
    public abstract void ReproductDna();
}
