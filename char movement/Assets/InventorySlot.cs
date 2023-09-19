using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class InventorySlot 
{   public ItemData itemData;
    public int stackSize;
    
    public InventorySlot(ItemData item){
        itemData=item;  //construct
        addStack();
    }
    public void addStack(){
        stackSize++;
    }
    public void removeStack(){
        stackSize--;
    }
    
   
}
