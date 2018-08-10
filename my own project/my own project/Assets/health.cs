using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{
    
          public Slider slider;
int health = 100;

    public Health()
    {
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