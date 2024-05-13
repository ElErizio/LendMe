using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool empezar = false;
    public float seconds;
    TextMeshProUGUI uiText;

    private void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (empezar)
        {
            seconds -= Time.deltaTime;
            if(seconds<= 0)
            {
                TimeIsUp();
            }
            int minutes = Mathf.FloorToInt(seconds / 60);
            int secs = Mathf.FloorToInt(seconds % 60);
            uiText.text = string.Format("{0:00}:{1:00}", minutes, secs);
        }
    }

    void TimeIsUp()
    {
        print("Se acabo el tiempo");
        empezar = false;
    }
}
