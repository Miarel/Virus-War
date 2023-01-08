using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellClickHandler : MonoBehaviour
{
    public static UnityEvent<GameObject> OnClickSomeObj = new UnityEvent<GameObject>();

    public static UnityEvent<EnemyCell> OnClickEnemyCell = new UnityEvent<EnemyCell>();
    public static UnityEvent<PlayerCell> OnClickPlayerCell = new UnityEvent<PlayerCell>();
    public static UnityEvent<NeutralCell> OnClickNeutralCell = new UnityEvent<NeutralCell>();

    public static UnityEvent<EnemyCell> OnLongClickEnemyCell = new UnityEvent<EnemyCell>();
    public static UnityEvent<PlayerCell> OnLongClickPlayerCell = new UnityEvent<PlayerCell>();

    [SerializeField] private float longClickDuration = 0.5f;

    private bool isLongClick;
    private float clickTime;

    [SerializeField] private float repeatRate = 0.25f;
    private float timeHeld = 0.0f;
    private float heldTime = 0.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickTime = Time.time;
            isLongClick = true;
            timeHeld = 0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isLongClick && Time.time - clickTime >= longClickDuration)
            {
                OnLongClickFinish();
            }
            else
            {
                OnClick();
            }
            isLongClick = false;
        }

        if (isLongClick)
        {
            timeHeld += Time.deltaTime;
            heldTime += Time.deltaTime;
            if (timeHeld >= longClickDuration && heldTime >= repeatRate)
            {
                OnLongClickHold();
                heldTime = 0.0f;
            }
        }
    }

    private void OnClick()
    {
        Debug.Log("Click");
        ClickRaycastHandler();
    }

    private void OnLongClickFinish()
    {
        Debug.Log("Long Click");
    }

    private void OnLongClickHold()
    {
        Debug.Log("Long Click");
        LongClickRaycastHandler();
    }

    private void ClickRaycastHandler()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (raycastHit == false) return;

        var cell = raycastHit.collider.transform.gameObject.GetComponent<Cell>();
        Debug.Log(cell);

        switch (cell)
        {
            case EnemyCell:
                Debug.Log("Click EnemyCell");
                OnClickEnemyCell?.Invoke(cell as EnemyCell);
                break;

            case PlayerCell:
                Debug.Log("Click PlayerCell");
                OnClickPlayerCell?.Invoke(cell as PlayerCell);
                break;

            case NeutralCell:
                Debug.Log("Click");
                OnClickNeutralCell?.Invoke(cell as NeutralCell);
                break;

            default:
                if (raycastHit.collider.transform.gameObject.GetComponent<Virus>() == null)
                    OnClickSomeObj?.Invoke(raycastHit.collider.transform.gameObject);
                break;
        }
    }

    private void LongClickRaycastHandler()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (raycastHit == false) return;
        var cell = raycastHit.collider.transform.gameObject.GetComponent<Cell>();

        switch (cell)
        {
            case EnemyCell:
                OnLongClickEnemyCell?.Invoke(cell as EnemyCell);
                break;

            case PlayerCell:
                OnLongClickPlayerCell?.Invoke(cell as PlayerCell);
                break;

            default:
                if (raycastHit.collider.transform.gameObject.GetComponent<Virus>() == null)
                    OnClickSomeObj?.Invoke(raycastHit.collider.transform.gameObject);
                break;
        }
    }
}
