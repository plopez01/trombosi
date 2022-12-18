using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Animator animator;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
    }
    public void showToast(string message)
    {
        text.text = message;
        animator.SetTrigger("ToastIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
