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
    public void setTo(InvestigacionButton investigation)
    {
        print("Setting current investigation to " + investigation.title);
        cost.gameObject.transform.parent.gameObject.SetActive(true);
        //title.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 490);
        title.text = investigation.title;
        description.text = investigation.desc;
        image.sprite = investigation.sprite;
        cost.text = investigation.cost.ToString();
        // TODO make button gray if not enough IPs
        this.invActiva = investigation;
    }

    public void purchase()
    {
        if (ipManager.points > invActiva.cost)
        {
            ipManager.points -= invActiva.cost;
            invActiva.purchase();
        }
    }

    public void doThing(int i)
    {
        print(i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
