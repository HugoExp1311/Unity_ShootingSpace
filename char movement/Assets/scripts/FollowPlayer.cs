using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
     Vector2 moveDir;  Transform target;
    [SerializeField] private Rigidbody2D rb;
   
    [SerializeField] private float followSpeed=4f;
    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
     Vector3 direction=(target.position-transform.position).normalized;
     float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Deg2Rad;
     moveDir=direction;  
    }
    private void FixedUpdate() {
        rb.velocity=new Vector2(moveDir.x,moveDir.y)*followSpeed;
    }
}
