using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class asdsad
{
    public int a;
    public int b;
}
public class TitleUI : StudyUI
{
    asdsad asd;
    [SerializeField] int aa;
    protected override void Start()
    {
        base.Start();
        asd = new asdsad();
        if (TestClass.fff == null)
            TestClass.fff = asd;
        print(TestClass.fff.a);
        TestClass.fff.a += 5;
    }

    public override void OpenPopup()
    {
        base.OpenPopup();
        
    }

    protected override void ButtonFunc(string btnName)
    {
        base.ButtonFunc(btnName);
        switch (btnName)
        {
            case "TestBtn":
                {
                    print("Test");
                    SceneManager.LoadScene("Game");
                }
                break;
            default:
                break;
        }
    }
}
