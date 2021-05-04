using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerialKod : MonoBehaviour
{
    public Text Text;
    public InputField InputField;
    public GameObject Panel;
    private float vvodi = 0;
    public GameObject Image;

    void Start ()
    {

    }
    // Start is called before the first frame update

    public void Vvod()
    {
        if (InputField.text == "4545")
        {
            Text.text = "Хорошо так уж и быть пропускаю";
            Panel.SetActive(false) ;
        }
        else
        {
            vvodi++;
            if (vvodi == 1)
            {
                Text.text = "Неправильно!";
            }
            if (vvodi == 2)
            {
                Text.text = "Я же сказал не правильно!";
            }
            if (vvodi == 3)
            {
                Text.text = "Тебе рил не сказали код?XD";
            }
            if (vvodi == 4)
            {
                Text.text = "Ну пытайся)";
            }
            if (vvodi == 5)
            {
                Text.text = "Интересно какой же код";
            }
            if (vvodi == 6)
            {
                Text.text = "Я ведь не знаю ЫХЫХЫХ";
            }
            if (vvodi == 7)
            {
                Text.text = "Зачем ты нажимаеш?";
            }
            if (vvodi == 8)
            {
                Text.text = "Ты же не знаеш код!";
            }
            if (vvodi == 9)
            {
                Text.text = "Уменя много дел";
            }
            if (vvodi == 10)
            {
                Text.text = "НЕ НАЖИМАЙ!";
            }
            if (vvodi == 11)
            {
                Text.text = "Я прошу пожалуйста прекрати";
            }
            if (vvodi == 12)
            {
                Text.text = "Ты на принцип идеш?";
            }
            if (vvodi == 13)
            {
                Text.text = "Хорошо";
            }
            if (vvodi == 14)
            {
                Image.SetActive(true);
            }

            
        }
    }

}
