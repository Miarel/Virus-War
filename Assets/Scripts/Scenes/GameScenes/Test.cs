using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : GameScene
{
    public override void Start()
    {
        Name = "Test";
        Debug.Log("Start " + Name);
    }

    public override void Update()
    {
        Debug.Log("Update" + Name);
    }
}
