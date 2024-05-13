using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public List<Timer> timers = new List<Timer>();

    public int startTime;

    private void Start()
    {
        timers.Clear();
        timers = new List<Timer>(FindObjectsOfType<Timer>());
        foreach (Timer timer in timers)
        {
            timer.seconds = startTime;
        }
        StartTimers();
    }

    [ContextMenu("StartTime")]
    public void StartTimers()
    {
        foreach (Timer timer in timers)
        {
            timer.empezar = true;
        }
    }
}
