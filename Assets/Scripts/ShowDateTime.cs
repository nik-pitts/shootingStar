using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShowDateTime : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI date;
    public DateTimeManager dtManager;

    private void Start()
    {
        DateTime startTime = dtManager.GetStartDateTime();
        time.text = startTime.Hour + ":" + startTime.Minute;
        date.text = startTime.Day + "/" + startTime.Month + "/" + startTime.Year;
    }
}
