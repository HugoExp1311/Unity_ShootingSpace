
using UnityEngine;

public class LoopTileMap : MonoBehaviour
{
     public Transform player;
    public float mapWidth = 20f; // Width of the map in world units
    public float mapHeight = 10f; // Height of the map in world units

    private void Update()
    {
        Vector3 pos = player.position;

        // Wrap player position horizontally
        if (pos.x > mapWidth / 2f)
        {
            pos.x -= mapWidth;
        }
        else if (pos.x < -mapWidth / 2f)
        {
            pos.x += mapWidth;
        }

        // Wrap player position vertically
        if (pos.y > mapHeight / 2f)
        {
            pos.y -= mapHeight;
        }
        else if (pos.y < -mapHeight / 2f)
        {
            pos.y += mapHeight;
        }

        player.position = pos;
    
    }
}
