using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    private bool isStoped;

    private float timeSpeed;

    private float pastTime;

    private float timeLeft;

    public static UnityEvent<float> StartTimer = new UnityEvent<float>();
    
    public static UnityEvent<float> StopTimer = new UnityEvent<float>();
    
    public static UnityEvent<float> ResumeTimer = new UnityEvent<float>();

    public static UnityEvent<float> EndTimer = new UnityEvent<float>();

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
        return pastTime;
    }

    public void Stop() { 
        isStoped = true;
    }

    public void Resume() {
        isStoped = false;
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

    }

    void Update()
    {
        MakeTick();
    }
}
