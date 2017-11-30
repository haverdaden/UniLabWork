using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float shootCooldown;
    public float shootingRate = 0.25f;

    public Transform shotPrefab;

    // Use this for initialization
    private void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (shootCooldown > 0)
            shootCooldown -= Time.deltaTime;
    }

    public bool CanAttack()
    {
        return shootCooldown <= 0f;
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack())
        {
            shootCooldown = shootingRate;
            var shotTransform = Instantiate(shotPrefab);
            shotTransform.position = transform.position;
            var shot =
                shotTransform.gameObject.GetComponent<Shot>();
            if (shot != null)
                shot.isEnemyShot = isEnemy;
            // Make the weapon shot always towards it
            var move =
                shotTransform.gameObject.GetComponent<Movement>();
            if (move != null)
                move.direction = transform.right;
        }
    }
}