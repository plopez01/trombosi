using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI antiCoagName;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private Image rendererButton;

    [SerializeField] private AnticoagulantData data;
    // Start is called before the first frame update
    void Start()
    {
        antiCoagName.text = data.name;
        cost.text = data.cost.ToString() + "€";
        rendererButton.color = data.color;
    }

}
