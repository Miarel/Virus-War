using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tutorial:GameScene
{
    [SerializeField] CellCreator _enemyCellCreator;
    [SerializeField] CellCreator _neutralCellCreator;
    [SerializeField] CellCreator _playerCellCreator;

    public IEnumerator deleay()
    {
        yield return new WaitForSeconds(5.1f);
        SceneLoader.LoadScene("TestScene");
    }

    public override void Start()
    {
        Name = "Tutorial";

        _enemyCellCreator.CreateCellAt(new Vector3 (0,0,0));
        
        _neutralCellCreator.CreateCellAt(new Vector3 (3,0,0));

        _playerCellCreator.CreateCellAt(new Vector3 (6,0,0));

    }

    public override void Update()
    {
    }
}
