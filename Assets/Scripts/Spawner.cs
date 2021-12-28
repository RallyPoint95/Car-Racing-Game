using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Vishal.Car_Racing_game
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] cars;
        public static Spawner instance;//making an instance for calling the spawner script in game manager script
        // Start is called before the first frame update
        void Start()
        {
            if (instance == null) //for calling the spawner script in game manager script
                instance = this;
            StartCoroutine(SpawnItems(2f));//calling the function at start of frame
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator SpawnItems(float time) { //this function is for to randomly spawn the cars on the game
            yield return new WaitForSecondsRealtime(time);
            Vector2 pos = new Vector2(Random.Range(0, 3), transform.position.y);//randomly generate cars in y-axis
            Instantiate(cars[Random.Range(0, cars.Length)], pos, Quaternion.identity);//this function is to take the cars and place it at certain position randomly
            StartCoroutine(SpawnItems(Random.Range(3f,4f)));// this is for spawn time of 3-7 seconds of other objects
        }

        //function to spawn the cars after resumed
        public void SpawnAgain()
        {
            StartCoroutine(SpawnItems(Random.Range(3f, 4f)));// this is for spawn time of 3-7 seconds of other objects
        }
    }
}
