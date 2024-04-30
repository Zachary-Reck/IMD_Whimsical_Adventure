using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class TeleportOnHit : MonoBehaviour
{
    public float teleportRadius = 5.0f;  // Radius within which to teleport
    public Transform player;  // Reference to the player's Transform

    void OnCollisionEnter(Collision collision)
    {
        // Teleport the object to a random location around the player within the specified radius
        Vector3 randomDirection = Random.insideUnitSphere * teleportRadius;
        randomDirection += player.position;  // Make sure it's around the player
        randomDirection.y = transform.position.y;  // Keep the y position the same to avoid moving up or down

        transform.position = randomDirection;
        
        // Rotate to face the player
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;  // Ensure the rotation only happens along the y-axis
        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = rotationToPlayer;
    }
}
