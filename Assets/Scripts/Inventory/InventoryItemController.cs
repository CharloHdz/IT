using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }


    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {

        switch (item.itemType) {

            case Item.ItemType.Potion:
                Player.Instance.UpdateHealth(item.value);
                break;
            case Item.ItemType.Helm:
                Equip(1);
                break;
            case Item.ItemType.Chest:
                Equip(2);
                break;
            case Item.ItemType.Boots:
                Equip(3);
                break;
        }

        RemoveItem();
    }

    public void Equip(int type)
    {
        Player.Instance.UpdateArm(item.arm);
        Player.Instance.UpdateStr(item.str);
        Player.Instance.UpdateSpd(item.spd);
        InventoryManager.Instance.EquipItem(type, item);
    }

    public void Unequip() 
    {
        Player.Instance.UpdateArm(item.arm);
        Player.Instance.UpdateStr(item.str);
        Player.Instance.UpdateSpd(item.spd);
    }

   
}
