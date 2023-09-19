using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{ public static objectPool current;
 public GameObject pool;
 public int poolNum;
 public bool WillGrow;
 private List <GameObject> poolList;
private void Awake() {
    current=this;
}
 void Start() { poolList= new List<GameObject>();
for(int i=0;i<poolNum;i++){
GameObject obj=Instantiate(pool);
obj.SetActive(false);
poolList.Add(obj);
}}
public GameObject GetPool(){
    for(int i=0;i<poolList.Count;i++){
if(!poolList[i].activeInHierarchy){
    return poolList[i];
}} 
if(WillGrow){
    GameObject obj=Instantiate(pool); 
    poolList.Add(obj); return obj;
}return null;}
}




