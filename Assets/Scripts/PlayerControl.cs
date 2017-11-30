using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D Rigidbody;

    public Vector2 speed = new Vector2(50, 50);

    // Use this for initialization
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Retrieve axis information
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        var shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        // Calculate movement
        movement = new Vector2(
            speed.x * inputX,
            speed.y * inputY);

        if (shoot)
        {
            var weapon = GetComponent<Weapon>();
            if (weapon != null)
            {
                weapon.Attack(false);
                soundEffects.Instance.MakePlayerShotSound();
            }
                
        }

        // Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)).y;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z);
    
    }

    private void FixedUpdate()
    {
        // updating the game object velocity
        Rigidbody.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;
        Enemy enemy =
            collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            HealthCheck enemyHealth = enemy.GetComponent<HealthCheck>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
            damagePlayer = true;
        }
        if (damagePlayer)
        {
            HealthCheck playerHealth = this.GetComponent<HealthCheck>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
}