
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger :MonoBehaviour
{
    
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(2);
        }
    }
    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("Fade Out");
    }
    public void OnFadeComplete(){
        SceneManager.LoadScene(2);
    }
}
