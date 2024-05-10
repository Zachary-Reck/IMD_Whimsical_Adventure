using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger2 : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject sword;

    void Start()
    {
        // Get the VideoPlayer component attached to the GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        // Find the GameObject tagged "Sword"
       // sword = GameObject.FindGameObjectWithTag("Weapon");
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player")) // Ensure your player GameObject has the tag "Player"
        {
            videoPlayer.Play();
            Invoke("ActivateSword", 7.5f); // Schedule sword activation in 10 seconds
        }
    }

    void ActivateSword()
    {
        if (sword != null)
        {
            sword.SetActive(true);
        }
    }
}
