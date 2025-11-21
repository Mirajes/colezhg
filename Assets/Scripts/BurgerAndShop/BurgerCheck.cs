using System.Collections.Generic;
using UnityEngine;

public class BurgerCheck : MonoBehaviour
{
    private void Burger(string ingr1, string ingr2, string ingr3, string ingr4, out string whatIsIt)
    {
        whatIsIt = "что это? ~ ~ыофшщыошв ";

        List<string> Ingredients = new List<string>() { ingr1, ingr2, ingr3, ingr4 };

        foreach (string item in Ingredients)
        {
            if (item.ToLower() == "сыр" || item.ToLower() == "кетчуп" || item.ToLower() == "котлета" || item.ToLower() == "огурец")
                whatIsIt = "чиииииизбургер";
        }

        foreach (var item in Ingredients)
        {
            if (item.ToLower() == "специальный соус" || item.ToLower() == "булочка с кунжутом" || item.ToLower() == "две котлеты")
                whatIsIt = "биг боб";
        }
    }

    private void Start()
    {
        Burger("сыр", "кетчуп", "котлета", "огурец", out string _whatIsIt1);
        Burger("специальный соус", "булочка с кунжутом", "две котлеты", "гвозди", out string _whatIsIt2);
        Burger("€йца", "молоко", "огрурец", "ничего", out string _whatIsIt3);

        print("первый: " + _whatIsIt1);
        print("второй: " + _whatIsIt2);
        print("третий: " + _whatIsIt3);
    }
}
