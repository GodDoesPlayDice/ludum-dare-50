using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DemandController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private Image image;
    [SerializeField] private TMP_Text textField;

    #endregion

    #region Fields

    public GoodType currentProduct { get; private set; }

    #endregion

    public void SetProduct(GoodType type, int count)
    {
        this.currentProduct = type;
        image.sprite = type.icon;
        textField.text = count.ToString();
    }
}
