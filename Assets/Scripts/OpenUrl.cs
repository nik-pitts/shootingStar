using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public void OpenURL()
    {
        string url = "https://docs.google.com/forms/d/1yUtomq9JwJDQdd3plJMIkoDF9jhyBx0xKwfhaf_qnlU/prefill";
        Application.OpenURL(url);
        Debug.Log("Working!");
    }
}
