using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot;
    public bool isPlayerShot;

    // Use this for initialization
    private void Start()
    {
        Destroy(gameObject, 10); // 10sec
    }

    // Update is called once per frame
    private void Update()
    {
    }
}