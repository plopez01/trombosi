using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFullfiller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI danger;

    private Animator dangerAnim;

    private int _money;
    private int _danger;

    private void Start()
    {
        dangerAnim = danger.GetComponent<Animator>();
    }

    public int Money
    {
        get { return _money; }
        set {
            _money = value;
            money.text = value.ToString() + "€"; 
        }
    }

    public int Danger
    {
        get { return _danger; }
        set {
            _danger = value;
            danger.text = value.ToString() + "%";
            dangerAnim.SetBool("Dangerous", _danger >= 90);
        }
    }
}
