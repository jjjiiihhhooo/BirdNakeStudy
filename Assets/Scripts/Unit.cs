using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int order;
    [SerializeField] private int speed;
    [SerializeField] private float timer;

    private int moveData;
    private Vector3 dir;

    public bool isBird;
    public int Order { set => order = value; get => order; }
    public int Timer { set => timer = value; }
    public int MoveData { set => moveData = value;}
    public Vector3 Dir { set => dir = value; get => dir; }

    //필요한 컴포넌트
    private Transform firePos;
    private UnitData unitData;
    private SpriteRenderer unitSprite;
    private Animator animator;

    private void Awake()
    {
        unitData = new UnitData();
        unitSprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveState();
        IsBird();
    }

    private void IsBird()
    {
        if (timer <= 0)
        {
            isBird = true;
            ChangeImage(1);
        }    
        else if(timer > 0 && !isBird)
            timer -= 0.1f;
    }

    private void MoveState()
    {
        switch (moveData)
        {
            case 0: // 따라가는.
                {
                    transform.position += Time.deltaTime * dir * speed;
                }
                break;
            case 1: // change
                {
                    transform.position += Time.deltaTime * dir * speed;
                }
                break;
        }
    }

    public void SetData(UnitData _unitData, RuntimeAnimatorController animatorController)
    {
        unitData = _unitData;
        animator.runtimeAnimatorController = animatorController;
        ChangeImage(0);
    }

    public void ChangeImage(int birdState)
    {
        if (birdState == 0)
        {
            unitSprite.sprite = TestSpriteZip.instance.unitImages[unitData.UnitType];
        }
        else if (birdState == 1)
        {
            unitSprite.sprite = TestSpriteZip.instance.unitImages[unitData.UnitKind];
        }

    }
}

