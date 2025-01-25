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
        int minutes = 0;
        if (timeInSeconds >= 60)
        {
            minutes = (int)((timeInSeconds) / 60f);
            timeInSeconds += (minutes * 60);
        }

        timerText.text = timeInSeconds.ToString();
    }
    
}