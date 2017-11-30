using UnityEngine;

public class Movement : MonoBehaviour
{
    //Moving direction
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D RigidBody;

    public Vector2 speed = new Vector2(10, 10);

    // Use this for initialization
    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Movement
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
    }

    private void FixedUpdate()
    {
        // Applying movement to the rigidbody
        RigidBody.velocity = movement;
    }
}