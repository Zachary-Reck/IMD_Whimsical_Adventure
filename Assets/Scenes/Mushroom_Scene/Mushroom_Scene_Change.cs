using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetTrigger("Fade In");
    }
}
