using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.Vishal.Car_Racing_game
{
    public class GameManager : MonoBehaviour
    {
        public GameObject pausePanel;
        public GameObject gameOverPanel;
        public AudioSource carDrivingSound;
        public AudioSource carCrashSound;
        public GameObject spawner;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //function for Pausing of game
        public void Pause()
        {
            spawner.SetActive(false);//to stop the spawn of cars in game when paused
            pausePanel.SetActive(true);//for pausing the game for certain time
            Time.timeScale = 0;
            carDrivingSound.Stop();// stop the sound
        }

        //function for resuming of game
        public void Resume()
        {
            spawner.SetActive(true);//again start the spawn of cars in game when resumed
            Spawner.instance.SpawnAgain();//instance called in spawner script to resume the spawn of cars when resumed
            carDrivingSound.Play();// play the sound
            Time.timeScale = 1;
            pausePanel.SetActive(false) ;//for resuming the game 
        }

        //function for Menu of game
        public void Menu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);//for loading the menu scene
        }

        //function for GameOver 
        public void GameOver()
        {
            gameOverPanel.SetActive(true);//for Quiting the game 
            Time.timeScale = 0;
        }

        //function for Restart of game
        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//for loading Active game scene for restart of game
        }

        //function if collision caused by player to other cars then game will be over or restart the game
        private void OnCollisionEnter2D(Collision2D other)
        {
            carDrivingSound.Stop();// stop the driving sound
            carCrashSound.Play();//play the car crash sound
            GameOver();
        }
    }
}
