using System;
using UnityEngine;

[Serializable]
public class Product : MonoBehaviour
{
    public SO_Product _product;

    public SO_Product SO_Product => _product;
}
