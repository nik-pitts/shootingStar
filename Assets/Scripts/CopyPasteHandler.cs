using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CopyPasteHandler
{ 
    public static string PasteFromClipBoard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.multiline = true;
        textEditor.Paste();
        Debug.Log(textEditor.text);
        return textEditor.text;
    }
}
