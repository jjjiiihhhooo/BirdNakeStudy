using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    [SerializeField] private Manager manager;
    private KeyCode[] keyCodes = 
    { 
        KeyCode.Alpha1, 
        KeyCode.Alpha2, 
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            manager.SetHeadMoveDir(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            manager.SetHeadMoveDir(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            manager.SetHeadMoveDir(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            manager.SetHeadMoveDir(Vector3.down);
        }

        for(int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                manager.ChangeUnit(i + 1);
                break;
            }
        }
    }
}
