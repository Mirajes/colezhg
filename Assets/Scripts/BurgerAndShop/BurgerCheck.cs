using System.Collections.Generic;
using UnityEngine;

public class BurgerCheck : MonoBehaviour
{
    private void Burger(string ingr1, string ingr2, string ingr3, string ingr4, out string whatIsIt)
    {
        whatIsIt = "что это? ~ ~ыофшщыошв ";

        List<string> Ingredients = new List<string>() { ingr1, ingr2, ingr3, ingr4 };

        List<string> CheeseBurger = new List<string>() { "сыр", "кетчуп", "котлета", "огурец" };
        int score_cheeseBurger = 0;

        List<string> BigMak = new List<string>() { "", "специальный соус", "булочка с кунжутом", "две котлеты" };
        int score_BigMak = 0;

        foreach (string item in Ingredients)
        {
            if (CheeseBurger.Contains(item.ToLower()))
            {
                score_cheeseBurger++;
                CheeseBurger.Remove(item.ToLower());
            }


            if (BigMak.Contains(item.ToLower()))
            {
                score_BigMak++;
                BigMak.Remove(item.ToLower());
            }
        }

        if (score_cheeseBurger == 4)
        {
            whatIsIt = "чииииизбургер"; return;
        }

        if (score_BigMak == 4)
        {
            whatIsIt = "биг боб"; return;
        }

    }

    private void Start()
    {
        Burger("сыр", "кетчуп", "котлета", "огурец", out string _whatIsIt1);
        Burger("специальный соус", "булочка с кунжутом", "две котлеты", "гвозди", out string _whatIsIt2);
        Burger("€йца", "молоко", "огрурец", "ничего", out string _whatIsIt3);
        Burger("специальный соус", "булочка с кунжутом", "две котлеты", "", out string _whatIsIt4);
        Burger("кетчуп", "сыр", "огурец", "котлета", out string _whatIsIt5);


        print("первый: " + _whatIsIt1);
        print("второй: " + _whatIsIt2);
        print("третий: " + _whatIsIt3);
        print("чертвЄртый: " + _whatIsIt4);
        print("п€тый" + _whatIsIt5);
    }
}
