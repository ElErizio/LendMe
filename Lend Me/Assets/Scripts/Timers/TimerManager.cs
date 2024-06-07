using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public List<Timer> timers = new List<Timer>();

    public int startTime;
    float seconds;
    public bool empezar = false;

    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        timers.Clear();
        timers = new List<Timer>(FindObjectsOfType<Timer>());
        seconds = startTime;
        empezar = true;
    }

    private void Update()
    {
        if (empezar)
        {
            seconds -= Time.deltaTime;

            if (seconds <= 0)
            {
                seconds = 0;
                TimeIsUp();
            }
            foreach (Timer timer in timers)
            {
                timer.SetTimeUI(seconds);
            }
        }
    }

    void TimeIsUp()
    {
        print("Se acabo el tiempo");
        empezar = false;
        StartCoroutine(PlaySound());
        FindObjectOfType<EnemySoawner>().SpawnEnemy();
    }

    IEnumerator PlaySound()
    {
        aud.Play();
        yield return new WaitForSeconds(3f);
        aud.Stop();
    }
}
