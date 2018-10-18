using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    public int currentSecond;
    public int currentMinute;
    public int currentHour;

    [HideInInspector] public GameObject secondHand;
    [HideInInspector] public GameObject minuteHand;
    [HideInInspector] public GameObject hourHand;

    private float rotateAngle = -6.0f;
    private float hourRotateAngle = -30.0f;
    private float secondDelay = 1.0f;
    private int seconds = 60;
    private WaitForSeconds secondWait;

    private void Start()
    {
        secondWait = new WaitForSeconds(secondDelay);
        Debug.Log(transform.childCount);
        StartCoroutine(Clock());
    }

    private IEnumerator Clock()
    {
        for (int l = 0; l < 12; l++)
        {
            for (int n = 0; n < 60; n++)
            {
                for (int i = 0; i < seconds; i++)
                {
                    secondHand.transform.Rotate(0, 0, rotateAngle);
                    currentSecond = i + 1;

                    yield return secondWait;
                }
                
                minuteHand.transform.Rotate(0, 0, rotateAngle);
                currentMinute = n + 1;
            }

            hourHand.transform.Rotate(0, 0, hourRotateAngle);
            currentHour = l + 1;
        }
    }
}
