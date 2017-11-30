using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameEntry : MonoBehaviour
{

    public Button EnemyButton;
    public Button PlayerButton;
    private RectTransform RectangleTransformEnemy;
    private RectTransform RectangleTransformPlayer;
    private bool EnemyButtonClicked;
    private bool PlayerButtonClicked;

    private void Start()
    {
        if (EnemyButton && PlayerButton)
        {
            RectangleTransformEnemy = EnemyButton.GetComponent<RectTransform>();
            RectangleTransformPlayer = PlayerButton.GetComponent<RectTransform>();
        }

    }


    public void MovePlayer()
    {
        PlayerButtonClicked = true;
        Destroy(PlayerButton.gameObject,10);
    }

    public void MoveEnemy()
    {
        EnemyButtonClicked = true;
        Destroy(EnemyButton.gameObject, 10);

    }
    public void LoadFirstLevel()
    {

        //Load next scene
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (EnemyButtonClicked && EnemyButton.gameObject)
        {
            RectangleTransformEnemy.position = new Vector3(RectangleTransformEnemy.position.x - 300 * Time.deltaTime, RectangleTransformEnemy.position.y, RectangleTransformEnemy.position.z);
        }
        if (PlayerButtonClicked && PlayerButton.gameObject)
        {
            RectangleTransformPlayer.position = new Vector3(RectangleTransformPlayer.position.x + 300 * Time.deltaTime, RectangleTransformPlayer.position.y, RectangleTransformPlayer.position.z);
        }


    }
}
