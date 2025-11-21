using UnityEngine;

[CreateAssetMenu(fileName = "SO_Product", menuName = "Scriptable Objects/SO_Product")]
public class SO_Product : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _price;

    public string Name => _name;
    public float Price => _price;

    public void ChangePrice(float multiplier)
    {
        _price *= multiplier;
    }
}
