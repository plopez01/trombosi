using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleEl;
    [SerializeField] private TextMeshProUGUI descriptionEl;
    [SerializeField] private Button okButton;
    [SerializeField] private Button nokButton;
    private TextMeshProUGUI nokText;
    private TextMeshProUGUI okText;
    [SerializeField] private Image imageEl;
    private Call okCallback, nokCallback;
    public delegate void Call();
    void Start()
    {
        okButton.onClick.AddListener(onOk);
        nokButton.onClick.AddListener(onNok);
        nokText = nokButton.GetComponentInChildren<TextMeshProUGUI>(true);
        okText = okButton.GetComponentInChildren<TextMeshProUGUI>(true);
    }
    public void openToast(
        string title,
        string desc,
        string ok,
        string nok,
        Sprite icon,
        Call okCallback,
        Call nokCallback)
    {
        print("Opening toast: " + title);

        gameObject.SetActive(true);
        titleEl.text = title;
        descriptionEl.text = desc;
        nokText.text = nok;
        okText.text = ok;
        imageEl.sprite = icon;
        this.okCallback = okCallback;
        this.nokCallback = nokCallback;

        gameObject.SetActive(true); // ?????? It works ig :))))))
    }
    private void onNok()
    {
        var call = nokCallback;
        close();
        call();
    }
    private void onOk()
    {
        var call = okCallback;
        close();
        call();
    }
    private void close()
    {
        nokCallback = null;
        okCallback = null;
        gameObject.SetActive(false);
    }
}
