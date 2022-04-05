using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UItext: MonoBehaviour
{
    private TMP_Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = this.GetComponent<TMP_Text>();
    }

    public void UpdateText(string UpdateText)
    {
        text.text = UpdateText;
    }

    internal void UpdateText(float gameTimerLimit)
    {
        throw new NotImplementedException();
    }
}
