using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour {

    public Animator animator;
    public TriggerBox triggerboxPrefab;
    public TriggerBox target_right;
    public TriggerBox target_left;
    private int levelToLoad;
    public wrmhlRead device;
    //TriggerBox box = target.AddComponent<TriggerBox>();

    // instantiate
    public void Start()
    {
        //target_right = Instantiate(triggerboxPrefab, new Vector3(-2.5f, 1.5f, -17.5f), Quaternion.identity);
        //target_left = Instantiate(triggerboxPrefab, new Vector3(2.5f, 1.5f, -17.5f), Quaternion.identity);
    }

    public void Update()
    {
        //print("Target Left Triggered: " + target_left.GetTriggered() + "\tTarget Right Triggered: " + target_right.GetTriggered());

        if (target_right.GetTriggered())
        {
            device.closeScene();
            FadeToLevel(1);
        }
        else if (target_left.GetTriggered())
        {
            device.closeScene();
            FadeToLevel(2);
        }
	}

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}