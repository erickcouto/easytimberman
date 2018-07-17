using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private SpriteRenderer sprite;
    private Animator anim;
    private Side actualSide = Side.left;


	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.gameOver)
        {

            sprite.flipX = false;
            anim.Play("die");

        }
    }


    void ChangeSide(Side newPosition) {


        if (actualSide != newPosition)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            sprite.flipX = !sprite.flipX;
            actualSide = newPosition;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.gameOver = true;
       
    }

    public void Toque(int side)
    {
        if (!GameManager.instance.gameOver)
        {
            ChangeSide((Side)side);
            anim.Play("cut");
        }
      

    }

    public enum Side
    {
        left,
        right
    }

}

