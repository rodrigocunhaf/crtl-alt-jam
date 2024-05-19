using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Munitions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI munitionsText;
    // Update is called once per frame
    public void SetUIMunitions(int total)
    {
        munitionsText.text = total.ToString();
    }
}
