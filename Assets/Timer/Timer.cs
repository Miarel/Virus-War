using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class Timer: MonoBehaviour
{
    private LevelHandler lh = new LevelHandler();
    [SerializeField] private float time;
    [SerializeField] private TMP_Text timerText;
 
    [SerializeField] private float _timeLeft = 0f;
 
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }
 
    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            _timeLeft = 0;
            LevelHandler.isTimeEnded = true;
        }
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}