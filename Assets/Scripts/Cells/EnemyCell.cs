using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCell : ActivityCell
{
    [SerializeField] private float pushVirusDellay = 1f;
    private float timePush = 0f;

    public override void Capture(Cell parent)
    {
        this.Invader = parent;
        CaptureCell.Invoke(this);
        CellCreator.CreateCellAt(gameObject.transform.position,parent);

        Destroy(gameObject);
    }

    public override void IncreaseScoreAt(float value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException("Incremented value cannot be less than 0");

        if (dnaCapacity - (dnaCount + value) > 0)
            dnaCount += value;
    }

    private void ChangeDnaTextLable(float newDnaValue)
    {
        dnaCoutTextLable.text = Convert.ToInt32(newDnaValue).ToString();
    }

    public override void IncreaseScore()
    {
        if (dnaCount <= dnaCapacity)
            dnaCount += reproductionSpeed * Time.deltaTime;
    }

    public override void TakeDamage(Cell cell,float damage)
    {
        if(damage < 0) throw new ArgumentOutOfRangeException("Damage cannot be less than 0");
        dnaCount -= damage;

        if (dnaCount <= 0)
            Capture(cell);
    }

    public override void PushVirus(Transform spawnTransform,Virus virus, Cell target)
    {
        if (target == this) return;
        
        if (timePush < pushVirusDellay) return;
        timePush = 0f;

        if (dnaCount - virus.Price >= 1) dnaCount -= virus.Price;
        else return;
        Instantiate(virus, spawnTransform).MoveTo(this,target.transform);
    }

    public override void Heal(Cell sender,float health)
    {
        if (health < 0) throw new ArgumentOutOfRangeException("Heal can't be less than 0");

        IncreaseScoreAt(health);
    }

    protected override void Start()
    {
        base.Start();
        OnChangeDnaCount.AddListener(ChangeDnaTextLable);
    }
    private void Update()
    {
        timePush += Time.deltaTime;
    }
}
