using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : MonoBehaviour
{
    private int playerSpeed = 10;
    public int playerJumpPower = 1200;
    private bool isDead = true;
    private float moveX = 0;

    void Start()
    {
        isDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isDead = gameObject.transform.position.y < -6;
        if (isDead) StartCoroutine("Die");
    }

    void Move()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            Jump();

        // Animation
        //GetComponent<Animator>().SetBool("MyCondition", (int)moveX != 0);


        // Direction
        // OLD SCHOOL //if ((moveX < 0 && !isFaceRight) || (moveX > 0 && isFaceRight)) Flip();
        GetComponent<SpriteRenderer>().flipX = moveX < 0f;

        // Physics
        var obj = gameObject.GetComponent<Rigidbody2D>();
        obj.velocity = new Vector2(moveX * playerSpeed, obj.velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    // OLD SCHOOL
    //void Flip()
    //{
    //    isFaceRight = !isFaceRight;
    //    var localScale = gameObject.transform.localScale;
    //    localScale.x *= -1;
    //    transform.localScale = localScale;
    //}

    private IEnumerator Die()
    {
        isDead = true;
        SceneManager.LoadScene("SampleScene");
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player has collided with" + collision?.collider?.name);
    }
}
