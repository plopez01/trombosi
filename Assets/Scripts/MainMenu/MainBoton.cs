using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBoton : MonoBehaviour
{
    private GameObject divMain;

    public void changeSceneTo(string scene)
    {
        //SceneManager.LoadScene(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        divMain = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
