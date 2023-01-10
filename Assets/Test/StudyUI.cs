using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StudyUI : MonoBehaviour
{
    [SerializeField] protected UnityEngine.UI.Button[] btns;
    [SerializeField] GameObject popup;
    protected virtual void Start()
    {
        foreach (UnityEngine.UI.Button btn in btns)
        {
            btn.onClick.AddListener(()=>ButtonFunc(btnName:btn.name));
        }
    }

    protected virtual void ButtonFunc(string btnName)
    {

    }

    protected virtual void ToggleFunc()
    {

    }

    protected virtual void SetText()
    {

    }

    public virtual void OpenPopup()
    {
        popup.SetActive(true);
    }

    public virtual void ClosePopup() 
    {
        popup.SetActive(false);
    }
}
