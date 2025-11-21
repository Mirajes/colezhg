using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
using static UnityEditor.Progress;

public class InternetShop : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _sectionPrefab;
    [SerializeField] private Transform _sectionContainer;
    [SerializeField] private Transform _basketContainer;

    private bool _isBasketActive = false;
    [SerializeField] private GameObject _basket;

    [Header("Products")]
    [SerializeField] private List<SO_Product> _products = new List<SO_Product>();

    private void Init()
    {
        foreach (SO_Product item in _products)
        {
            GameObject newSection = Instantiate(_sectionPrefab, _sectionContainer);
            newSection.name = item.Name;
            newSection.GetComponent<Product>()._product = item;

            // я понятия не имею как делать подругому 
            // ниже не работает 
            //newSection.GetComponent<TMP_Text>().CompareTag("SectionName") ? newSection.GetComponent<TMP_Text>().text = item.Name : newSection.GetComponent<TMP_Text>().text = "";

            TMP_Text[] A = newSection.GetComponentsInChildren<TMP_Text>();

            foreach (TMP_Text TMP in A)
            {
                if (TMP.CompareTag("SectionName"))
                    TMP.text = item.Name;

                if (TMP.CompareTag("SectionPrice"))
                    TMP.text = item.Price.ToString();
            }
        }
    }


    private void UpdateContainer(Transform container)
    {
        foreach (Transform item in container)
        {
            TMP_Text[] TMP = item.GetComponentsInChildren<TMP_Text>();

            foreach (TMP_Text textSection in TMP)
            {
                if (textSection.CompareTag("SectionPrice"))
                {
                    string text = textSection.text;
                    float.TryParse(text, out float price);
                    textSection.text = (price * 2).ToString();
                }
            }
        }
    }

    public void AddToBasket(Product product)
    {
        GameObject newSection = Instantiate(_sectionPrefab, _basketContainer);

        TMP_Text[] tmp = newSection.GetComponentsInChildren<TMP_Text>();

        foreach (TMP_Text TMP in tmp)
        {
            if (TMP.CompareTag("SectionName"))
                TMP.text = product.SO_Product.Name; 

            if (TMP.CompareTag("SectionPrice"))
                TMP.text = product.SO_Product.Price.ToString();
        }
    }


    public void NextDay()
    {
        UpdateContainer(_sectionContainer);
        UpdateContainer(_basketContainer);
    }

    public void SeeBasket()
    {
        _isBasketActive = !_isBasketActive;
        _basket.SetActive(_isBasketActive);
    }


    private void Awake()
    {
        Init();
    }

}

