using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] private float _timerDuration = 60;

    private bool _isRunning = false;

    public float TimeValue {  get; private set; }

    private void Update()
    {
        if (_isRunning == false)
            return;

        if (TimeValue > 0)
            TimeValue -= Time.deltaTime;
        else
            TimeValue = 0;

        DisplayTime(CalculateMinutes(TimeValue), CalculateSeconds(TimeValue));
    }

    private void DisplayTime(float minutes, float seconds)
    {
        _timerText.gameObject.SetActive(true);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private float CalculateMinutes(float time)
    {
        return Mathf.FloorToInt(time / 60);
    }

    private float CalculateSeconds(float time)
    {
        return Mathf.FloorToInt(time % 60);
    }

    public void StartTimer()
    {
        _isRunning = true;
    }

    public void ResetTimer()
    {
        TimeValue = _timerDuration;
    }

    public void Stop()
    {
        _isRunning = false;
        _timerText.gameObject.SetActive(false);
    }
}
