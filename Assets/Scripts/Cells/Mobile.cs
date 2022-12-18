using UnityEngine;

public interface Mobile
{
    public void Move(Mobile from, Mobile to);
    
    public void Move(Mobile from, Mobile to, float speed);

    public void Move(Transform target);
}
