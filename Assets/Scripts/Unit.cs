using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Unit : MonoBehaviour , IDamaged
{
    [SerializeField] private int order;
    [SerializeField] private int speed;
    [SerializeField] private float timer;

    private int hp = 30;
    private Vector3 dir;

    public bool isBird;
    public int Hp { get => hp; }
    public int Order { set => order = value; get => order; }
    public int Timer { set => timer = value; }
    public Vector3 Dir { set => dir = value; get => dir; }

    //필요한 컴포넌트
    private UnitData unitData;
    private SpriteRenderer unitSprite;
    public Animator animator;

    private void Awake()
    {
        unitData = new UnitData();
        unitSprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveState();
        if(!isBird)
        {
            if (timer > 0)
                timer -= 0.1f;
            else if(timer <= 0)
                IsBird();
        }
        
    }

    private void IsBird()
    {
        isBird = true;
        ChangeImage(1);
    }

    private void MoveState()
    {
        transform.position += Time.deltaTime * dir * speed;
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
    
    public void SetDamaged(int _damage)
    {
        hp -= _damage;
    }
}

