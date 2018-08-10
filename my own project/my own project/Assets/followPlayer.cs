using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class followPlayer : MonoBehaviour {
    
    GameObject player;
    public float speed;
    public Transform target;
    public float health;


	private void Start()

	{
        player = GameObject.FindGameObjectWithTag("Player");
	}
	private void Update()
	{
        Vector2 dir = (player.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = dir * speed ;

	}
	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag == "Player")
            speed = 0;
	}
}
