using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBoton : MonoBehaviour
{
    private GameObject divMain;
    private Animator animator;

    public void changeSceneTo(string scene)
    {
        animator.SetBool("Fade", true);
        //SceneManager.LoadScene(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        divMain = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
