using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private IPManager ipManager;
    [SerializeField] private Image image;
    [SerializeField] private string defaultTitle;
    [SerializeField] private string defaultDesc;
    [SerializeField] private Toaster toaster;
    private InvestigacionButton invActiva;
    void Start()
    {
        resetModal();
    }
    public void resetModal()
    {
        title.text = defaultTitle;
        description.text = defaultDesc;
        //title.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 600);
        cost.gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void setTo(InvestigacionButton inv)
    {
        print("Setting current investigation to " + inv.title);
        cost.gameObject.transform.parent.gameObject.SetActive(true);
        //title.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 490);
        title.text = inv.title;
        description.text = inv.desc;
        image.sprite = inv.sprite;
        cost.text = inv.isMaxed ? "MAX" : inv.cost.ToString();
        // TODO make button gray if not enough IPs
        this.invActiva = inv;
    }

    public void purchase()
    {
        if (invActiva.isMaxed)
        {
            toaster.showToast("Already maxed!");
            return;
        }
        print(invActiva.currentLevel);
        if (ipManager.points > invActiva.cost)
        {
            ipManager.points -= invActiva.cost;
            invActiva.purchase();
            setTo(invActiva);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
