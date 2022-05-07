using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    public Vector3[] targetPoints;
    Button[] buttons;
    public Vector3 targetPos;
    public bool show;
    private void Start()
    {
        buttons = transform.GetComponentsInChildren<Button>(true);
        targetPoints = new Vector3[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            targetPoints[i] = buttons[i].GetComponent<RectTransform>().anchoredPosition;
            buttons[i].gameObject.SetActive(false);
        }
        
    }
    void Update()
    {
        if (show)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(buttons[i].GetComponent<RectTransform>().anchoredPosition, targetPoints[i], Time.deltaTime * 10);
                buttons[i].gameObject.SetActive(true);
            }
        }
        else 
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(buttons[i].GetComponent<RectTransform>().anchoredPosition, targetPos, Time.deltaTime * 10);
            }
        }
    }
    public void SetUIState() 
    {
        show = !show;
    }
}
