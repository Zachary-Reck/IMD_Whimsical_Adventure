using UnityEngine;

public class TeleportOnClick : MonoBehaviour
{
    public Transform player;
    public string anotherObjectTag = "Chest";
    public float teleportRadius = 5.0f;
    public float interactionDistance = 3.0f;
    public float delay = 2.0f;
    private int hitCounter = 0;
    private GameObject anotherObject;

     public AudioClip myAudioClip; 
     public AudioSource myAudioSource; 

    void Start()
    {
        anotherObject = GameObject.FindWithTag(anotherObjectTag);
        if (anotherObject != null)
        {
            anotherObject.SetActive(false);
            Debug.Log("Another object set to inactive on start.");
        }
        else
        {
            Debug.Log("Failed to find object with tag: " + anotherObjectTag);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= interactionDistance)
            {
                Debug.Log("Player is close enough to teleport the mushroom.");
            
                Invoke("TeleportMushroom", delay);
            }
        }
    }

    void TeleportMushroom()
    {
        Vector3 randomDirection = Random.insideUnitSphere * teleportRadius;
        randomDirection += player.position;
        randomDirection.y = transform.position.y;
        transform.position = randomDirection;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        directionToPlayer.y = 0;
        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = rotationToPlayer;
        hitCounter++;

        if (hitCounter >= 5)
        {

            gameObject.SetActive(false);
            PlayTheMusic();
            if (anotherObject != null)
            {
                anotherObject.SetActive(true);
                Debug.Log("Another object set to active after 5 hits.");
            }
        }
    }

     public void PlayTheMusic()
    {
          myAudioSource.clip = myAudioClip;  // Set the AudioClip to the AudioSource
            myAudioSource.Play();    
    }
}
