using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private Toaster toaster;
    public void exerciseUp()
    {
        toaster.showToast("Improved exercise levels!");
    }
    public void dietUp()
    {
        toaster.showToast("Your diet has improved!");
    }
    public void thirdUp()
    {
        toaster.showToast("Your status has improved!");
    }
}
