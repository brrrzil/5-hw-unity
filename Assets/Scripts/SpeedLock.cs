using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLock : MonoBehaviour
{
    public Text timer;
    private float currentTime, clickTime;
    public Text pinA, pinB, pinC;
    public float remainingTime;

    [SerializeField] private GameObject TimeLoosePanel;
    [SerializeField] private GameObject CounterLoosePanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject StartPanel;

    int a, b, c;

    public void Start()
    {
        randomizer();
    }

    public void randomizer()
    {
        a = Random.Range(1, 10);
        b = Random.Range(1, 10);
        c = Random.Range(1, 10);

        if ((a + b + c) % 5 != 0)
        {
            randomizer();
        }
    }

    public void StartButton()
    {
        randomizer();
        clickTime = Mathf.Round(Time.time);
        TimeLoosePanel.SetActive(false);
        CounterLoosePanel.SetActive(false);
        WinPanel.SetActive(false);
        StartPanel.SetActive(false);
    }

    public void butU()
    {
        a = a + 1;
        b = b + 1;
        c = c + 1;
    }

    public void butD()
    {
        a = a - 1;
        b = b - 1;
        c = c - 1;
    }

    public void butA()
    {
        a = a + 1;
        b = b - 1;
    }

    public void butB()
    {
        a = a - 1;
        b = b + 2;
        c = c - 1;
    }

    public void butC()
    {
        a = a - 1;
        b = b + 0;
        c = c + 1;
    }

    void Update()
    {
        currentTime = clickTime + remainingTime - Mathf.Round(Time.time);
        timer.text = currentTime.ToString();
        pinA.text = a.ToString();
        pinB.text = b.ToString();
        pinC.text = c.ToString();

        if (currentTime <= 0)
        {
            timer.text = "0";
            TimeLoosePanel.SetActive(true);
        }

        if ((a > 9) || (b > 9) || (c > 9) || (a < 0) || (b < 0) || (c < 0))
        {
            timer.text = "0";
            CounterLoosePanel.SetActive(true);
        }

        if ((a == 5) && (b == 5) && (c == 5))
        {
            timer.text = "0";
            WinPanel.SetActive(true);
        }
    }
}
