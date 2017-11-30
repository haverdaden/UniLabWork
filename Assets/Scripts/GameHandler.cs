using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class GameHandler : MonoBehaviour
    {

        public void StartGameOver()
        {
            StartCoroutine(GameOver());
        }

        public  IEnumerator GameOver()
        {
            yield return new WaitForSeconds(3.0f);

            SceneManager.LoadScene("GameOverScene");
        }
    }

