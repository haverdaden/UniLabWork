using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthCheck : MonoBehaviour
{
    public int hp = 1;
    private GameHandler GameHandler;
    public bool isEnemy = true;
    private Slider HealthSlider;
    private static int enemycount;
    private Text Score;


    private void Start()
    {
        GameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
        HealthSlider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        Score.text = "Score: " + enemycount;
    }


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        var shot = otherCollider.gameObject.GetComponent<Shot>();

        if (shot != null)
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject);
            }
    }

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (!isEnemy)
        {
            HealthSlider.value--;
        }

        if (hp <= 0)
        {
            if (isEnemy)
            {
                enemycount++;
                Score.text = "Score: " + enemycount;
            }

            if (!isEnemy)
            {
                GameHandler.StartGameOver();
                enemycount = 0;
            }
                

            visualEffects.Instance.Explosion(transform.position);
            soundEffects.Instance.MakeExplosionSound();
            Destroy(gameObject);

            if (enemycount > 5)
            {
                System.Threading.Thread.Sleep(10); //work
                // load the game win level
                enemycount = 0;
                SceneManager.LoadScene("GameWin");
            }

        }
    }

}