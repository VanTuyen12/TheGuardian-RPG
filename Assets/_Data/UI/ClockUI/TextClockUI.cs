using System;
using UnityEngine;

public class TextClockUI : TextAbstract
{
    private float startTime;
    private float totalPlayTime = 0f;
    [SerializeField] private double checkTimer = 30.0;
    [SerializeField]private double nextSpawnTime = 0.0;
    [SerializeField]private bool isReached  = false;
    public bool IsReached => isReached;

    protected override void Start()
    {
        base.Start();
        startTime = Time.time;
        nextSpawnTime = checkTimer;
    }

    private void Update()
    {
        totalPlayTime  = Time.time - startTime;
        
        TimeSpan  playTimeSpan  = TimeSpan.FromSeconds(totalPlayTime);
        int minutes = (int)playTimeSpan .TotalHours;
        
        float secondsWithDecimal = (float)playTimeSpan.Seconds + (float)playTimeSpan.Milliseconds / 1000f;
        txtProUi.text = string.Format("{0:00}:{1:00}", minutes, secondsWithDecimal.ToString("00.00s"));

        if (!(playTimeSpan.TotalSeconds >= nextSpawnTime) || isReached) return;
        isReached = true;
        DoSomething();
        nextSpawnTime += checkTimer;
        
        Debug.Log("Logg at " + playTimeSpan.ToString("mm\\:ss\\.fff"));
    }

    protected virtual void DoSomething()
    {
        GameEvent.CheckTimerSpawn(true);
        isReached = false;
    }
}
