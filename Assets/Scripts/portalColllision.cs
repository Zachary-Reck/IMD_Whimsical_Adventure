using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalColllision : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            //SceneManager.LoadScene("Portal");
            animator.SetTrigger("Fade Out");
        }
    }
    public void OnFadeComplete(){
        SceneManager.LoadScene(1);
    }
    
}
