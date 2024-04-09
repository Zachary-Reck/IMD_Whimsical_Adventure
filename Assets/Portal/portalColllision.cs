using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalColllision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Mushroom");
        }

    }
}
