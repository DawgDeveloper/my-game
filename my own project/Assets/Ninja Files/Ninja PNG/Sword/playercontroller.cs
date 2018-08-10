using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class playercontroller : MonoBehaviour {
    public float speed = 20;
    private Rigidbody2D rigd2d;
    private Animator anim;
    private Vector3 leftScale;
    private Vector3 rightScale;
    public float jumpSpeed ;
    public float max;
     public const float MAXHEALTH = 100;
    public Slider slider;

    [SerializeField]
    private float currentHealth;

    public float _currentHealth
    {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }

    [SerializeField]
    private bool dead;
    private int health;

    public bool _dead
    {
        get { return dead; }
        private set { dead = value; }
    }
	// Use this for initialization
	void Start () {
        rigd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rightScale = transform.localScale;
        leftScale = rightScale;
        leftScale.x = -rightScale.x;
        _currentHealth = MAXHEALTH;
        _dead = false;
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        rigd2d.velocity = new Vector2(h, rigd2d.velocity.y);
        if (h != 0)
            anim.SetBool("Run", true);
        else anim.SetBool("Run", false);
        if (h > 0)
            transform.localScale = rightScale;
        else if (h < 0)
            transform.localScale = leftScale;
        
            anim.SetBool("attack", Input.GetKeyDown(KeyCode.L));
        if (_currentHealth <= 0)
        {
            _dead = true;
        }

    }

    public void TakeDmg(float amount)
    {
        if (_currentHealth - amount < 0)
            _currentHealth -= amount;
        else _currentHealth = 0;
    }
    public void Heal(float amount)
    {
        if (_currentHealth + amount < MAXHEALTH)
            _currentHealth += amount;
        else _currentHealth = MAXHEALTH;
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





