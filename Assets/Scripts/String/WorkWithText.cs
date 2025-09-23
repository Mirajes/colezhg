using System;
using System.Text;
using TMPro;
using UnityEngine;

public class WorkWithText : MonoBehaviour
{
    [SerializeField]
    private string givenText =
        "Cats are j*st h*ge kittens and n$othing else. These cr$azy animals ar$e preferred by a h*ge part of those who keep animals at home. People alw$ays thin$k that cats are lazy animals that lik$e t$o spend their ent$ire life sitting by the wind$ow, all day long.>We have all heard that ca$ts live an average of 8 years, b*t that is no$t the entire tr*th. This n*mber is only ave$rage, cats live 12 ye$ars and more on a$verage. Cats are s$ocial a$nimals, they live with other cats and th$ey als$o$ live with h*mans and other anim$als as well.>Cats live *p to 40 ho*rs a week, so they can not even be c$onsidered as lazy. They play with other animals and they spend tim$e sleeping or lo*nging aro*nd. They enjoy long walks a$nd we all$ know cats will.>It is easy to bring a kitten home, b*t it is not so $easy to raise and raise a worthy member of mo$dern society and make a decent cat o*t of a $baby. Before yo* bring a new cat home, it is im$portant to know how to take care of them and train them properly.>They req*ire the p$roper space, shelter and toys. Cats can be kept in a normal room with doors and wind$ows open, b*t don’t expo$se them $to the we$ather. If yo* want them to play o*tside and go on long walks, keep them inside the ho*se. The ho*se m*st be clean, a$nd food and water m*st alwa$ys be availa$ble. If yo* want yo*r cat to like yo*, yo* m*st be nice $to him or her.>A $cat is a *niq*e creat*re, she has different needs and a different disposition. If yo* choose$ the wrong one to k$eep, yo* mig$ht regret it. Cats are an im$portant part of o*r world, an$d we have to give them the$ right ed*ca$tion.zzz";
    [SerializeField] private TMP_Text stringWindow;

    private void Start()
    {
        stringWindow.text = givenText;
    }

    public void Decrypt()
    {
        stringWindow.text = stringWindow.text.Replace("*", "u");
    }

    public void Correct()
    {
        stringWindow.text = stringWindow.text.Replace('>', '\n');
    }

    public void Peel()
    {
        stringWindow.text = stringWindow.text.Replace("$", "");
    }

    public void Encrypt()
    {
        string newText = "";

        for (int i = 0; i < stringWindow.text.Length; i++)
        {
            char current = stringWindow.text[i];
            int c = (int)current - 1;

            if (c == 31)
            {
                c = 126;
            }

            char next = (char)c;
            //int ascii = Convert.ToInt32(stringWindow.text[i]);

            newText += next.ToString();

        }

        stringWindow.text = newText;
        Binary();
    }

    public void Recrypt()
    {
        string newText = "";

        for (int i = 0; i < stringWindow.text.Length; i++)
        {
            char current = stringWindow.text[i];
            int c = (int)current + 1;

            if (c == 127)
            {
                c = 32;
            }

            char next = (char)c;

            newText += next.ToString();
        }


        stringWindow.text = newText;
        Binary();
    }

    public void Binary()
    {
        byte[] bytes = Encoding.UTF8.GetBytes(givenText);
        string binaryString = ToBinaryString(bytes);

        stringWindow.text = binaryString;
    }

    private string ToBinaryString(byte[] bytes)
    {
        string binaryString = "";
        foreach (byte b in bytes)
        {
            string binaryByte = Convert.ToString(b, 2).PadLeft(8, '0');
            binaryString += binaryByte;
        }
        return binaryString;
    }

    public void ResetText()
    {
        stringWindow.text = givenText;
    }
}
