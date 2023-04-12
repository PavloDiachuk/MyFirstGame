using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//Библиотеки
public class PlayerCNTRL : MonoBehaviour
{
    //Переменная для отображения счета
    public Text text;
    //Скорость движения шарика
    public float speed = 5f;
    //Переменная с помощью которой шарик двигаеться
    Rigidbody _rb;
    //Текущий Счет
    private int _score = 0;

    private void Awake()
    {
        //Получаем компонент для передвижения
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //3 строки нижа отвечают за передвижения
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _rb.AddForce(new Vector3(h, 0, v) * speed);
    }
    private void OnTriggerEnter(Collider other)
    {   //Когда мы трогаем триггер(кубик) он пропадает и нам добавляеться счет :)
        if (other.gameObject.tag == "AddScore")
        {
            Destroy(other.gameObject);
            _score++;
            if (_score != 4)
             text.text = "Score" + _score;
            else
                text.text = "Ur win GG:" + _score; // :)
            
        }
    }
}
