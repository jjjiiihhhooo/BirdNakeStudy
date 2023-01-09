using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private Unit unit;

    [SerializeField] private List<Unit> unitList;


    private void Awake()
    {
        unitList = new List<Unit>();
    }

    private void Start()
    {
        for(int i = 0; i < size; i++) 
        {
            CreatePool();
        }
    }
    private void CreatePool()
    {
        Unit u = Instantiate(unit,transform);
        unitList.Add(u);
        u.gameObject.SetActive(false);
    }

    /// <summary>
    /// <code1>¿Ø¥÷ º“»Ø</code1>
    /// <code2>¿Ø¥÷ ∆À</code2>
    /// </summary>
    /// <returns></returns>
    public Unit PopUnit()
    {
        Unit u = null;
        for(int i = 0; i< unitList.Count ; i++)
        {
            if (unitList[i].gameObject.activeSelf== false)
            {
                u = unitList[i];
                break;
            }
        }
        if (u == null)
        {
            CreatePool();
            u = unitList[unitList.Count - 1];
        }
        return u;
    }
}


