using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   //play sound khi trigger enter 2d;
    public static AudioManager instance=null; //check xem sound effect co bi trung khong, 
    //enforce chi co duy nhat cai instance la dang chay
    public AudioSource audioSource; //chinh volume va pitch of sound
     private void Awake() {  //singleton!!
       if (instance ==null) { //chua trung
        instance=this;
       } 
       else if(instance!=this){ //trung already exists
        Destroy(gameObject);
       } DontDestroyOnLoad(this);
    }
    public void playClip(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
}
