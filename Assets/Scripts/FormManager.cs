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

    private void Start()
    {
    }

    public void Send(string entryId)
    {
        // Send() is called when user hits enter
        StartCoroutine(Post(reponse.text, entryId));
    }

    IEnumerator Post(string responseText, string entryId)
    {
        WWWForm form = new WWWForm();
        form.AddField(entryId, responseText);

        UnityWebRequest www = UnityWebRequest.Post(formResponseUrl, form);

        yield return www.SendWebRequest();
    }
}
