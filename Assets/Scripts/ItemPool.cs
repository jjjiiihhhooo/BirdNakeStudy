using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private Item item;
    [SerializeField] private List<Item> itemList;

    private void Awake()
    {
        itemList = new List<Item>();
    }

    private void Start()
    {
        for (int i = 0; i < size; i++)
        {
            CreatePool();
        }
    }

    private void SetActiveItem(GameObject _item)
    {
        _item.gameObject.SetActive(true);
    }

    private void CreatePool()
    {
        Item temp = Instantiate(item, transform);
        itemList.Add(temp);
    }

    public Item PopItem()
    {
        Item temp = null;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].gameObject.activeSelf == false)
            {
                temp = itemList[i];
                break;
            }
        }
        if (temp == null)
        {
            CreatePool();
            temp = itemList[itemList.Count - 1];
        }
        return temp;
    }
}
