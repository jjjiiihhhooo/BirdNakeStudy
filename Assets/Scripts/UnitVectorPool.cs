using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitVectorPool : MonoBehaviour
{
    [SerializeField] private int size;

    [SerializeField] private int order;

    [SerializeField] private UnitVector unitVector;
    [SerializeField] private List<UnitVector>unitVectorList;


    private void Awake()
    {
        unitVectorList = new List<UnitVector>();
    }

    private void Start()
    {
        for (int i = 0; i < size; i++)
        {
            CreatePool();
        }
    }
    private void CreatePool()
    {
        UnitVector u = Instantiate(unitVector, transform);
        unitVectorList.Add(u);
        unitVectorList[order].Order = order;
        order++;
    }

    public UnitVector PopUnit()
    {
        UnitVector u = null;
        for (int i = 0; i < unitVectorList.Count; i++)
        {
            if (unitVectorList[i].gameObject.activeSelf == false)
            {
                u = unitVectorList[i];
                break;
            }
        }
        if (u == null)
        {
            CreatePool();
            u = unitVectorList[unitVectorList.Count - 1];
        }
        return u;
    }
}
