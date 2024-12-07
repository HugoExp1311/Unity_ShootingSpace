using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;


public class PathType : MonoBehaviour
{
    public enum PathTypes { Down, Circular, Square,Rectangle,UpRectangle , Curve, Zigzag, WhiteCell, LeftRight, MoveTeleRandom } //option to select
    public PathTypes pathType = PathTypes.Down; // option in default

    public float baseSpeed = 5f;
    private float radius = 10f; // For circular path
    private float sideLength = 12f; // For square path
    private float frequency = 4f; // For curve and zigzag paths How fast the bullet moves in the sine wave pattern
    private float magnitude = 2f; // For curve and zigzag paths How wide the sine wave is

    private float angle = 0f; // For circular path
    private Vector3 startPos; // For square, curve, and zigzag paths
    private int currentEdge = 0; // For square path
    private float traveledDistance = 0f;
    private float time=0, spawn=10f; 
    
    public float maxDistance = 5f; // Maximum distance before changing direction x:17
        public float zigzagAngle = 20f; // Angle in degrees

    public float decreaseY = 0.1f;  private bool movingRight = true;
    public float deadZone=-15f;
    float timer=10f; float count=0f; 


    void Start()
    {
        startPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<healthMain>(out healthMain healthMain)){
            healthMain.TakeDamage(1000);
        }}

    void Update()
    {
        
        switch (pathType)
        {
            case PathTypes.Down:
                MoveDown();
                break;
            case PathTypes.Circular:
                MoveInCircle();
                break;
            case PathTypes.Square:
                MoveInSquare();
                break;
            case PathTypes.Rectangle:
                MoveInRectangle();
                break;
            case PathTypes.UpRectangle:
                MoveUpFromLeft();
                break;
            case PathTypes.Curve:
                MoveInCurve();
                break;
            case PathTypes.Zigzag:
                MoveInZigzag();
                break;
             case PathTypes.WhiteCell:
               MoveReturnNull();
                break;
            case PathTypes.LeftRight:
                MoveLeftandRight();
                break;
            case PathTypes.MoveTeleRandom:
                MoveTeleRandom();
                break;
                
        }
         if(gameObject.transform.position.y<deadZone){Destroy(gameObject);}
    }

  void MoveDown()
    {
        
       Vector3 moveDir= new Vector3(0,-1);
        if(transform.position.y>4){
    transform.position+=moveDir*baseSpeed*Time.deltaTime;} 
    else{
    if(count<=timer){
        count+=0.005f; 
    }
    else{ transform.position+=moveDir*baseSpeed*Time.deltaTime;
    }}}
    void MoveUpFromLeft(){
        
        float distanceToMove = baseSpeed * Time.deltaTime;
        traveledDistance += distanceToMove;

        float currentSideLength = (currentEdge % 2 == 1) ? sideLength * 2 : sideLength;

        // Check if the bullet has reached the end of the current side
        if (traveledDistance >= currentSideLength)
        {
            traveledDistance -= currentSideLength; // Keep the overflow distance
            currentEdge = (currentEdge + 1) % 4; // Move to the next edge
            startPos = transform.position; // Update the start position for the new edge
        }

        Vector3 direction = Vector3.zero;
        switch (currentEdge)
        {
            case 0: // Move right for the longer side
                direction = Vector3.up;
                break;
            case 1: // Move down for the shorter side
                direction = Vector3.right;
                break;
            case 2: // Move left for the longer side
                direction = Vector3.down;
                break;
            case 3: // Move up for the shorter side
                direction = Vector3.left;
                break;
        }

        transform.position = startPos + direction * traveledDistance;
    
    }
   void MoveLeftandRight(){
        
        float distanceToMove = baseSpeed * Time.deltaTime;
        traveledDistance += distanceToMove;

        float currentSideLength = sideLength;

        // Check if the bullet has reached the end of the current side
        if (traveledDistance >= currentSideLength)
        {
            traveledDistance -= currentSideLength; // Keep the overflow distance
            currentEdge = (currentEdge + 1) % 2; // Move to the next edge
            startPos = transform.position; // Update the start position for the new edge
        
        }

        Vector3 direction = Vector3.zero;
        switch (currentEdge)
        {
            case 0: // Move right for the longer side
                direction = Vector3.left;
                break;
            case 1: // Move down for the shorter side
                direction = Vector3.right;
                break;
           
        }

        transform.position = startPos + direction * traveledDistance;
    
    }
   
void MoveTeleRandom(){ //14x,4y
        if(time<spawn){time+=.5f;}
        else{

         float newx=Random.Range(-14,14);
        float newy=Random.Range(0,4);
       
        startPos.x = newx;
        startPos.y = newy;
        transform.position= startPos;
time=0f;
        }
    
    }

    void MoveInCircle()
    {
        // Adjust speed for circular path based on the radius
        float adjustedSpeed = baseSpeed / radius;
        angle += adjustedSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void MoveInSquare()
    {
        // Adjust speed for square path to cover equal distance per frame
        float adjustedSpeed = baseSpeed;
        float distanceToMove = adjustedSpeed * Time.deltaTime;
        traveledDistance += distanceToMove;

        if (traveledDistance >= sideLength)
        {
            traveledDistance -= sideLength;
            currentEdge = (currentEdge + 1) % 4;
            startPos = transform.position;
        }

        Vector3 direction = Vector3.zero;
        switch (currentEdge)
        {
            case 0:
                direction = Vector3.right;
                break;
            case 1:
                direction = Vector3.down;
                break;
            case 2:
                direction = Vector3.left;
                break;
            case 3:
                direction = Vector3.up;
                break;
        }

        transform.position = startPos + direction * traveledDistance;
    }
   void MoveInRectangle()
    {
        float distanceToMove = baseSpeed * Time.deltaTime;
        traveledDistance += distanceToMove;

        float currentSideLength = (currentEdge % 2 == 0) ? sideLength * 2 : sideLength;

        // Check if the bullet has reached the end of the current side
        if (traveledDistance >= currentSideLength)
        {
            traveledDistance -= currentSideLength; // Keep the overflow distance
            currentEdge = (currentEdge + 1) % 4; // Move to the next edge
            startPos = transform.position; // Update the start position for the new edge
        }

        Vector3 direction = Vector3.zero;
        switch (currentEdge)
        {
            case 0: // Move right for the longer side
                direction = Vector3.right;
                break;
            case 1: // Move down for the shorter side
                direction = Vector3.down;
                break;
            case 2: // Move left for the longer side
                direction = Vector3.left;
                break;
            case 3: // Move up for the shorter side
                direction = Vector3.up;
                break;
        }

        transform.position = startPos + direction * traveledDistance;
    }

    void MoveInCurve()
{
    // Calculate the distance to move this frame
    float distanceToMove = baseSpeed * Time.deltaTime;

    // Update the traveled distance
    traveledDistance += distanceToMove;

    // Check if the bullet has reached the maximum distance
    if (movingRight && transform.position.x >= maxDistance)
    {
        // Change direction to the left and decrease y position slightly
        movingRight = false;
        startPos = new Vector3(transform.position.x, transform.position.y - decreaseY, transform.position.z);
        traveledDistance = 0f; // Reset traveled distance after changing direction
    }
    else if (!movingRight && transform.position.x <= -maxDistance)
    {
        // Change direction to the right and decrease y position slightly
        movingRight = true;
        startPos = new Vector3(transform.position.x, transform.position.y - decreaseY, transform.position.z);
        traveledDistance = 0f; // Reset traveled distance after changing direction
    }

    // Move the bullet forward or backward based on the direction
    Vector3 direction = movingRight ? transform.right : -transform.right;
    transform.position += direction * distanceToMove;

    // Apply the sine wave offset
    Vector3 offset = transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    transform.position = startPos + direction * traveledDistance + offset;
}

     void MoveInZigzag()
    {
         // Calculate the distance to move this frame
        float distanceToMove = baseSpeed * Time.deltaTime;

        // Update the traveled distance
        traveledDistance += distanceToMove;

        // Move the bullet forward or backward based on the direction
        Vector3 direction = movingRight ? transform.right : -transform.right;

        // Calculate the Y offset based on the angle
        float radianAngle = Mathf.Deg2Rad * zigzagAngle; // doi do angle sang radian
        float yOffset = Mathf.Tan(radianAngle) * distanceToMove;

        // Check if the bullet has reached the maximum distance for the current direction
        if (movingRight && traveledDistance >= maxDistance)
        {
            // Change direction to the left and update the start position for the new Y position
            movingRight = false;
            startPos = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z);
            traveledDistance = 0f; // Reset traveled distance after changing direction
        }
        else if (!movingRight && traveledDistance >= maxDistance)
        {
            // Change direction to the right and update the start position for the new Y position
            movingRight = true;
            startPos = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z);
            traveledDistance = 0f; // Reset traveled distance after changing direction
        }

        // Apply the movement
        transform.position += direction * distanceToMove;

        // Apply the diagonal downward movement when changing direction
        if (!movingRight)
        {
            transform.position += Vector3.down * yOffset;
        }
        
    
}
void MoveReturnNull(){
    //do nothing
}

/*float newwaypoint=waypoints.Length;
        // Check if there are waypoints defined
        if (waypoints.Length == 0) return;

        // Get the target waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Move towards the target waypoint
        float step = baseSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

        // Check if the bullet has reached the target waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.001f)
        {
            // Move to the next waypoint if available
            if (currentWaypointIndex < newwaypoint - 1)
            {
                currentWaypointIndex++;
            }
            else
            {
                // Stop the bullet when the final waypoint is reached
                enabled = false;
                newwaypoint--;
            }
        
    }*/

}
