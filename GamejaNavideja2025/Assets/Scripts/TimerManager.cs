using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public TMP_Text timerText;
    private float elapsedTime;

    public float ElapsedTime
    {
        get { return elapsedTime; }
        set { elapsedTime = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int timeInSeconds = (int)elapsedTime;
        int minutes = timeInSeconds / 60; // Calculate minutes
        int seconds = timeInSeconds % 60; // Calculate remaining seconds

        FormatTimerText(minutes, seconds);
        

    }

    private void FormatTimerText(int minutes, int seconds)
    {
        if (minutes > 0)
        {
            timerText.text = $"{minutes}:{seconds:D2}";
        }
        else
        {
            timerText.text = $"{seconds:D2}";
        }
    }
}