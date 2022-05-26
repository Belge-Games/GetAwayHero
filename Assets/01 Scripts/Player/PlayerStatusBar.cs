using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBar : MonoBehaviour
{
    [SerializeField] private Transform statusBar;
    [SerializeField] private TMPro.TextMeshProUGUI statusBarText;

    public void SetState(float current, float max)
    {
        float state = current / max;
        if(state <= 0f)
        {
            state = 0f;
        } 
        if(statusBar != null)
        {
            statusBar.transform.localScale = new Vector3(state, 1f, 1f);
        }
    }

    public void SetText(string text)
    {
        if(statusBarText != null) {
            statusBarText.SetText(text);
        }
    }
}
