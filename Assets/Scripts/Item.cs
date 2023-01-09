using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField] private Manager manager;
    private float x, y;

    private SpriteRenderer itemSprite;
    int eggType;
    private void Start()
    {
        itemSprite= GetComponent<SpriteRenderer>();
        eggType = Random.Range(0, 12);
        Init();
    }

    private void Init()
    {
        manager.Init(eggType);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "head")
        {

            x = Random.Range(-8, 8);
            y = Random.Range(-4, 4);
  
            manager.GetItem(this.transform, eggType);
            eggType = Random.Range(0, 12);
            itemSprite.sprite = TestSpriteZip.instance.unitImages[12+eggType];
            transform.position = new Vector3(x, y, 0);
        }
    }



}
