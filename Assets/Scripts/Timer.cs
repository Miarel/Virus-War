using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    private bool isStoped;

    [SerializeField] private float timeSpeed;

    private float timePast;

    [SerializeField] private float timeLeft;

    public static UnityEvent<float> StartTimer = new UnityEvent<float>();
    public static UnityEvent<float> ResumeTimer = new UnityEvent<float>();
    public static UnityEvent<float> StopTimer = new UnityEvent<float>();
    
    public static UnityEvent<float> EndTimer = new UnityEvent<float>();

    public static UnityEvent<float> TimeLeft = new UnityEvent<float>();
    public static UnityEvent<float> TimePast = new UnityEvent<float>();

    public void IncreaseTimer(float value) {
        timeLeft += value;
    }

    public void DecreaseTimer(float value) {
        timeLeft -= value;
    }

    public float GetTimer() {
        return timeLeft;
    }

    public float GetSpendTime() {
        return timePast;
    }

    public void Stop() { 
        isStoped = true;
        StopTimer.Invoke(timeLeft);
    }

    public void Start() {
        isStoped = false;
        StartTimer.Invoke(timeLeft);
    }

    private void Resume()
    {
        isStoped = false;
        ResumeTimer.Invoke(timeLeft);
    }

    public void IncreaseTimerSpeed(float value)
    {
        timeSpeed += value;
    }

    public void DecreaseTimerSpeed(float value)
    {
        timeLeft -= value;
    }

    private void MakeTick()
    {
        if (isStoped) return;
      
        if (timeLeft < 0)
        {
            LevelHandler.isTimeEnded = true;
            EndTimer.Invoke(timePast);
        }
        else
        {
            timePast += timeSpeed * Time.deltaTime;
            timeLeft -= timeSpeed * Time.deltaTime;

            TimeLeft.Invoke(timeLeft);
            TimePast.Invoke(timePast);
        }
    }

    void Update()
    {
        MakeTick();
    }
}
