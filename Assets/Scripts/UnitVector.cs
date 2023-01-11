using Newtonsoft.Json.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitVector : MonoBehaviour
{
    [SerializeField] private int order;
    private int speed = 5;
    private Vector3 dir;

    public Vector3 Dir { set => dir = value; get => dir; }
    public int Order { set => order = value; get => order; }

    private void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }
}
