using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

abstract public class Scene : MonoBehaviour 
{
    public string Name { get; protected set; } = "Empty Scene Name";

    public abstract void Start();
  
    public abstract void Update();

   
}
