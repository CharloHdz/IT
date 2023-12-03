using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public List<Item> Equiped = new List<Item>();
    public Transform ItemContent, EquipContent;
    public GameObject InventoryItem;
    public InventoryItemController[] InventoryItems;
    public InventoryItemController[] EquipItems;

    private void Awake()
    {
        Instance = this;

    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    

    public void Remove(Item item)
    {
        Items.Remove(item);
    } 



    public void ListItems()
    {
        CleanItems();
        //Agregar items

        foreach ( var item in Items  )
        {

            //Instanciar un espacio y agregar las cosas
          
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ImageIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            var eqButton = obj.transform.Find("Equipar").GetComponent<Button>();
            //Les pone el nombre y el ícono respectivos
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        
        SetInventoryItems();
    }

    public void EquipItem(int type, Item item)
    {
        if(type == 1)
        {
            GameObject menu = GameObject.Find("Helmet");
            var itemName = menu.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = menu.transform.Find("ImageIcon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }else if(type == 2)
        {
            GameObject menu = GameObject.Find("Chest");
            var itemName = menu.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = menu.transform.Find("ImageIcon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }else if(type == 3)
        {
            GameObject menu = GameObject.Find("Boots");
            var itemName = menu.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = menu.transform.Find("ImageIcon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        
        
        
    }



    public void CleanItems()
    {
        //Limpieza del inventario
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
       

    }

    public void SetInventoryItems()
    {
        
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
       
        for(int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
       
    }

    public void SetEquipedItems()
    {
        EquipItems = EquipContent.GetComponentsInChildren<InventoryItemController>();
        for(int i = 0; i < Equiped.Count; i++)
        {
            EquipItems[i].AddItem(Equiped[i]);
        }
    }
    
}

   