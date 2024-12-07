using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class inventory : MonoBehaviour
{
    public int coinCount; public UnityEvent coinIncrement;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    private Dictionary<ItemData,InventorySlot> itemDictionary =new Dictionary<ItemData, InventorySlot>();
   /*public bool pickItem(GameObject obj){
    switch(obj.tag){
        case "coin": coinCount++; return true;
        default:
        Debug.LogWarning($"not yet tagged this shit");
        return false;
    }} 
*/

    public void Add(ItemData itemData){
        if(itemDictionary.TryGetValue(itemData,out InventorySlot item)){  //stack
            item.addStack();
            coinCount++;
        }
    else{
        InventorySlot newitem= new InventorySlot(itemData);  //new item has been added
        inventorySlots.Add(newitem);
        itemDictionary.Add(itemData,newitem);
        coinCount++;
        
    }
    coinIncrement.Invoke();
    }
    public void Remove(ItemData itemData){
        if(itemDictionary.TryGetValue(itemData,out InventorySlot item)){
            item.removeStack();
            if(item.stackSize==0){
                inventorySlots.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
   }
private void OnEnable() {
    coin.OnCollectCoin+=Add;
}
private void OnDisable() {
    coin.OnCollectCoin-=Add;
}
   }

   
    


