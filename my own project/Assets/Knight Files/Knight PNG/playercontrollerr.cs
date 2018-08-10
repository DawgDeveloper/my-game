using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class playercontrollerr : MonoBehaviour
{

    //This is the speed of the racket mouvement
    public float speed = 30;
    public float jump = 10;
        public Slider slider;
    int health = 100;
    void FixedUpdate()
    {
        //This is our GetAxisRaw input 
                float v = Input.GetAxisRaw("Horizontal") * speed;
        //Just calling the Rigidbody2D component to change its Velocity value
        GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0);
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("walk", true);
        }
        else GetComponent<Animator>().SetBool("walk", false);
        if (Input.GetKeyDown(KeyCode.Space))

        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<Animator>().SetTrigger("attack");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            health -= 10;
            slider.value = health;
        }

        Debug.Log(health);


    }
}