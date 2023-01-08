using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PushableVirus
{
    void PushVirus(Transform spawnTransform,Virus virus,Cell target);
}
