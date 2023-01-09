using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpriteZip : MonoBehaviour
{
    public static TestSpriteZip instance;
    [SerializeField] public Sprite[] unitImages;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != null)
        {
            Destroy(this);
        }
    }
    
}
