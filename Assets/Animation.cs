using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public GameObject MainCamera; //аттач главной камеры для получения вектора направления движения
public GameObject Player; //Объект игрок
 
public static bool _gameover; //условие проигрыша
 
private float speed; //Скорость перемещения
private Rigidbody rb; //Физическое тело
private bool grounded; // На земле ли персонаж?
private bool moveForward; // Двигается вперед персонаж?
private bool moveBack; // Двигается назад персонаж?
private bool moveRight; // Двигается право персонаж?
private bool moveLeft; // Двигается влево персонаж?
 
//Задаем переменные при старте игры
    void Start()
    {
        grounded = true;
        rb = Player.GetComponent<Rigidbody>();
        _gameover = false;
        speed = 300;
        moveForward = false;
        moveBack = false;
        moveRight = false;
        moveLeft = false;
     }
 
//Теперь опишем, что должен делать персонаж при нажатых клавишах
 
void Update()
    {
        //Двигаемся вперед по вектору камеры
        if (Input.GetKey(KeyCode.W) & _gameover == false)
        {
            moveForward = true;
            if (grounded == true)
            {
                rb.AddForce(MainCamera.transform.forward * speed * Time.deltaTime);
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveForward = false;
        }
        //Движение назад по вектору камеры
        if (Input.GetKey(KeyCode.S) & _gameover == false)
        {
            if (grounded == true)
            {
                rb.AddForce(-MainCamera.transform.forward * speed * Time.deltaTime);
                moveBack = true;
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveBack = false;
        }
 
        //Движение вправо по вектору камеры
        if (Input.GetKey(KeyCode.D) & _gameover == false)
        {
            if (grounded == true)
            {
                rb.AddForce(MainCamera.transform.right * speed * Time.deltaTime);
                moveRight = true;
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveRight = false;
        }
        //Движение влево по вектору камеры
        if (Input.GetKey(KeyCode.A) & _gameover == false)
        {
            if (grounded == true)
            {
                rb.AddForce(-MainCamera.transform.right * speed * Time.deltaTime);
                moveLeft = true;
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveLeft = false;
        }
    }
}
