using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActivityCell : Cell, ScoreIncrease, PushableVirus, Healing
{
    [SerializeField] public UnityEvent<float> OnChangeDnaCount = new UnityEvent<float>();

    [SerializeField] protected TextMeshPro dnaCoutTextLable;
  
    [SerializeField] public float _dnaCount = 1;
    [SerializeField] public int dnaCapacity = 25;
    [SerializeField] public float reproductionSpeed = 1;
    [SerializeField] public float reproductionTime = 1;

    public float dnaCount { 
        get { return _dnaCount; }

        protected set {
            _dnaCount = value; 
            OnChangeDnaCount.Invoke(_dnaCount); 
        } 
    }

    public abstract void IncreaseScoreAt(float value);
    public abstract void IncreaseScore();
    public abstract void PushVirus(Transform spawnPoint, Virus virus, Cell target);
    public abstract void Heal(Cell sender,float health);
    
    protected virtual void Start()
    {
        dnaCoutTextLable = GetComponentInChildren<TextMeshPro>();
        dnaCoutTextLable.text = dnaCount.ToString();
    }

}
