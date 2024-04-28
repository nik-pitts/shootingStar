using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyPasteHandler : MonoBehaviour
{
    public string prefilledFormUrl;

    public void PasteFromClipBoard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.multiline = true;
        textEditor.Paste();
        prefilledFormUrl = textEditor.text;
        Debug.Log(prefilledFormUrl);
    }
}
