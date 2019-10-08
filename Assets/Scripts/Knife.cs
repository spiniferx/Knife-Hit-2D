using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Vector2 throwForce;
    public bool isEnabled;

    public Rigidbody2D rigidbody;
    public BoxCollider2D coll;
    public GameManager gm;

    public int count;
    public int hitCount;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        isEnabled = true;
        gm = FindObjectOfType<GameManager>();
        count = 0;
    }
    void Update()
    {
        count++;
        if(Input.GetMouseButtonDown(0) && isEnabled==true)
         {
             rigidbody.AddForce(throwForce,ForceMode2D.Impulse);
             rigidbody.gravityScale = 1f;    
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(isEnabled==false)
        {
            return;
        }

        if(other.collider.tag=="board")
        {
            rigidbody.velocity = new Vector2(0,0);
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(other.collider.transform);

            coll.offset = new Vector2(coll.offset.x, -0.8f);
            coll.size = new Vector2(2.2f,7f);
            hitCount++;
            gm.GameWon(hitCount);

            gm.newKnife();

        }
        else if(other.collider.tag=="knife")
        {
            Debug.Log("Knife Collided");
            rigidbody.velocity = new Vector2(0,-2);
            gm.GameLost();
        }
    }
}
