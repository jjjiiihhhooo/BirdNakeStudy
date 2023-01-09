using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[System.Serializable]
public class UnitData
{
    int unitKind;
    public int UnitKind { get => unitKind; }
    int unitType;
    public int UnitType { get => unitType; }

    public void SetUnitInfo(int _unitKind, int _unitType)
    {
        unitKind= _unitKind;
        unitType= _unitType;    
    }
}

public class Manager : MonoBehaviour
{
    [SerializeField] private bool testBool;
    private int currentSize = 0;

    [SerializeField] private List<Unit> units;
    [SerializeField] private UnitPool unitPool;

    public Sprite[] eggImage;
    public Sprite[] birdImage;

    private RuntimeAnimatorController animator;

    public UnitData[] unitdatas;
    private void Start()
    {
        animator = GetComponent<RuntimeAnimatorController>();
        unitdatas = new UnitData[12];
        for(int i =0; i< unitdatas.Length; i++)
        {
            unitdatas[i] = new UnitData();
            unitdatas[i].SetUnitInfo(i, 12+i);
        }
    }

    public void Init(int eggType)
    {
        SpawnUnit(this.transform, eggType);
        units[0].Timer = 0;
    }

    private void SpawnUnit(Transform _transform, int eggType)
    {
        Unit test = unitPool.PopUnit();
        units.Add(test);
        test.transform.position = _transform.position;
        test.gameObject.SetActive(true);
        test.SetData(unitdatas[eggType], animator);
        test.Order = currentSize++;
        if (test.Order == 0)
            test.tag = "head";
        else
            test.tag = "body";
    }

    public void GetItem(Transform _transform, int eggType)
    {
        SpawnUnit(_transform, eggType);
    }

    public void GetDamage(int _order)
    {
        units[_order].gameObject.SetActive(false);
        units[_order].Timer = 300;
        units[_order].isBird= false;
        units.RemoveAt(_order);
        currentSize--;
        for(int i = _order; i < currentSize; i++)
        {
            units[i].Order -= 1; 
        }
        if (_order == 0)
            units[_order].tag = "head";
    }


    public Sprite SetImage(int _check)
    {
        int random = Random.Range(0, eggImage.Length - 1);

        if(_check == 0)
            return eggImage[random];
        else
            return birdImage[random];
    }

    private void Update()
    {
        SetBodyMoveDir();

        if(testBool)
        {
            testBool = false;
        }
    }

    public void SetHeadMoveDir(Vector3 dir)
    {
        units[0].Dir = dir;
    }

    private void SetBodyMoveDir()
    {
        Vector3 tempDir;
        for(int i = 1; i < currentSize; i++)
        {
            tempDir = units[units[i].Order - 1].transform.position - units[i].transform.position;
            units[i].Dir = tempDir;
        }
    }


    public void ChangeUnit(int _change)
    {
        if (_change < currentSize && units[_change].isBird)
        {
            Unit temp = units[_change];
            units[_change].tag = "head";
            units[_change].Order = 0;
            units[_change] = units[0];
            units[0].Order = _change;
            units[0].tag = "body";
            units[0] = temp;

        }
    }

    //private void SetOrder(int i)
    //{
    //    Units[i].OrderChange(i);
    //}

    //private void SetKeyInput(int i)
    //{
    //    Units[i].GetKeyInput(keyInput);
    //}

    //private void ChangeImage(int i, Sprite egg, Sprite bird)
    //{
    //    Units[i].SetImage(egg, bird);
    //}

    //private void SetFront()
    //{
    //    Units[0].tag = "head";
    //    for(int i = 1; i < size; i++)
    //    {
    //        Units[i].SetFrontUnit(Units[Units[i].order - 1]);
    //        Units[i].tag = "body";
    //    }
    //}
}
