using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public static UnityEvent<EnemyCell> OnClickEnemyCell = new UnityEvent<EnemyCell>();
    public static UnityEvent<PlayerCell> OnClickPlayerCell = new UnityEvent<PlayerCell>();
    public static UnityEvent<NeutralCell> OnClickNeutralCell = new UnityEvent<NeutralCell>();

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("button down");
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if(raycastHit.collider!=null)
            {
                Debug.Log("raycasted");
                var target = raycastHit.collider.transform.gameObject;
                var cell = target.GetComponent<Cell>();

                switch (cell) {
                    case EnemyCell: {
                        Debug.Log("Enemy Hit");
                        Debug.Log(target.transform.position);
                        OnClickEnemyCell?.Invoke(cell as EnemyCell);
                        break;
                    }

                    case PlayerCell: { 
                        Debug.Log("Player Hit"); 
                        Debug.Log(target.transform.position);
                        OnClickPlayerCell?.Invoke(cell as PlayerCell);
                        break;
                    }

                    case NeutralCell: { 
                        Debug.Log("Neutral Hit"); 
                        Debug.Log(target.transform.position);
                        OnClickNeutralCell?.Invoke(cell as NeutralCell);
                        break;
                    }
                    default: { 
                        Debug.Log("???");
                        break;
                    }
                }    
            }
        }
    }
}
