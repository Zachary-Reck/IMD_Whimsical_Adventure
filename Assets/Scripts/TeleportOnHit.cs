using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnHit : MonoBehaviour
{
    public float teleportRadius = 5.0f;  // Radius within which to teleport
    public Transform player;  // Reference to the player's Transform

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);  // Log the name of the object entering the trigger
        // Check if the collider that entered the trigger has the tag "Sword"
        if (other.gameObject.tag == "Sword")
        {
            // Teleport the object to a random location around the player within the specified radius
            Vector3 randomDirection = Random.insideUnitSphere * teleportRadius;
            randomDirection += player.position;  // Calculate position around the player
            randomDirection.y = transform.position.y;  // Keep the y position the same to avoid vertical movement
            
            transform.position = randomDirection;
            
            // Optionally, rotate to face the player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0;  // Ensure the rotation only happens along the y-axis
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = rotationToPlayer;
        }
    }
}
