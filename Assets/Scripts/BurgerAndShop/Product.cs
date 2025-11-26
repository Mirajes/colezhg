using System;
using TMPro;
using UnityEngine;

public class Product : MonoBehaviour
{
    public SO_Product ProductData { get; private set; }

    [SerializeField] private TMP_Text _productName;
    [SerializeField] private TMP_Text _productPrice;

    public static Action<string, string> ButtonOnRelease;


    
}
