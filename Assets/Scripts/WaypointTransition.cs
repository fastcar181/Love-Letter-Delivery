using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner confiner;
    [SerializeField] Direction direction;
    [SerializeField] float positionOffset = 3;
    enum Direction {  Forward, Backward, Left, Right }
    private void Awake(){
        confiner = FindObjectOfType<CinemachineConfiner>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            confiner.m_BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPosition = player.transform.position; // Get the player's current position
        // Decide where/how far to move the player after the transition
        switch (direction)
        {
            case Direction.Forward:
                newPosition.y += positionOffset;
                break;
            case Direction.Backward:
                newPosition.y -= positionOffset;
                break;
            case Direction.Left:
                newPosition.x -= positionOffset;
                break;
            case Direction.Right:
                newPosition.x += positionOffset;
                break;
        }
        player.transform.position = newPosition; // Update the player's position after the  transition
    }

 
}
