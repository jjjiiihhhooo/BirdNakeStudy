using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    private int eggType;
    private float x, y;

    [SerializeField] private Manager manager;

    private SpriteRenderer itemSprite;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        SetPosition();
        itemSprite = GetComponent<SpriteRenderer>();
        eggType = Random.Range(0, 12);
        itemSprite.sprite = TestSpriteZip.instance.unitImages[12 + eggType];
    }

    private void SetPosition()
    {
        x = Random.Range(-8, 8);
        y = Random.Range(-4, 4);
        transform.position = new Vector3(x, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "head")
        {
            manager.GetItem(this.transform, eggType);
            eggType = Random.Range(0, 12);
            itemSprite.sprite = TestSpriteZip.instance.unitImages[12+eggType];
            SetPosition();
        }
    }
}
