using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.Vishal.Car_Racing_game
{
    public class MenuManager : MonoBehaviour
    {
        public AudioSource clickSound;
        public GameObject quitPanel;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))//condition to check if back button on android is pressed this quitPanel is set to true 
                quitPanel.SetActive(true);
        }

        //function for playing click sound
        public void ClickSound()
        {
            clickSound.Play();
        }

        //function for play click sound when play button is pressed
        public void play()
        {
            clickSound.Play();
            SceneManager.LoadScene(1);
        }

        //function for quiting the game
        public void Quit()
        {
            Application.Quit();
        }
    }
}
