using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom_Change : MonoBehaviour
{
    private MeshRenderer m_meshRenderer;
    private void Start(){
        m_meshRenderer = GetComponent<MeshRenderer>();
    }
    public Material lit;
    public Material unlit;
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            m_meshRenderer.material = unlit;
        }
    }
}
