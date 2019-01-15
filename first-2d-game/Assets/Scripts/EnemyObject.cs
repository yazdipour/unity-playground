using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public int Speed = 1;
    public int XMoveDirection = 1;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * Speed;
        if (hit.distance < .5f) Flip();
    }

    private void Flip() => XMoveDirection *= -1;
}
