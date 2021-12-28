using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Vishal.Car_Racing_game
{
    public class Score : MonoBehaviour
    {
        public Text scoreText;
        float score;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            score += 3 * Time.deltaTime;
            scoreText.text = "Score: " + (int)score;
            if (PlayerPrefs.GetInt("BestScore") < score)// this condition is for if you have new best score the best score is set to score
            {
                PlayerPrefs.SetInt("BestScore", (int)score);
            }
        }
    }
}
