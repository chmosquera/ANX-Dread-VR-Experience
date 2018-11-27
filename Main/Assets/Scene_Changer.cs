using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour {

    public Animator animator;
    public GameObject target;
    private int levelToLoad;
    TriggerBox box = new TriggerBox();

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (box.OnTrigger(other))
        {
            FadeToLevel(1);
        }
	}

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
