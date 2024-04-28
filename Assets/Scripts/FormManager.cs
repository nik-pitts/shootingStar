using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FormManager : MonoBehaviour
{
    [SerializeField] TMP_InputField reponse;
    private string formResponseUrl = "https://docs.google.com/forms/d/e/1FAIpQLSdnMwTtLy5Y6KOZMV4xPtN9r4Tzn2cd60K1mhXrHPhWqDLj2w/formResponse";
    private string[] formEntryCode = new string[6];

    private void Start()
    {
        formEntryCode[0] = "entry.787779239";
        formEntryCode[1] = "entry.1851785395";
        formEntryCode[2] = "entry.170349516";
        formEntryCode[3] = "entry.2121724733";
        formEntryCode[4] = "entry.456285609";
        formEntryCode[5] = "entry.502436794";
    }

    public void Send()
    {
        // Send() is called when user hits enter
        StartCoroutine(Post(reponse.text));
    }

    IEnumerator Post(string responseText)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.787779239", responseText);

        UnityWebRequest www = UnityWebRequest.Post(formResponseUrl, form);

        yield return www.SendWebRequest();
    }
}
