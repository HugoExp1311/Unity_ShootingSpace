using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
     Vector2 moveDir;  Transform target,target2;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float minSpeed=2f;
     [SerializeField] private float maxSpeed=5f;

   private float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        followSpeed=Random.Range(minSpeed,maxSpeed);
       // target=GameObject.FindWithTag("Gate").transform;
        target=GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update() //ham update dung de xu ly vector direction
    {
     Vector3 direction=(target.position-transform.position).normalized;
     float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Deg2Rad;
     moveDir=direction;  
    }
    private void FixedUpdate() { // ham fixedupdate dung de xu ly di chuyen
        rb.velocity=new Vector2(moveDir.x,moveDir.y)*followSpeed;
    }
}
