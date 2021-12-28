using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Vishal.Car_Racing_game
{
    public class Player_Movement : MonoBehaviour
    {
        private Rigidbody2D rb;
        public float speed;
        public float sideSpeed;
        public AudioSource carMoveUD;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Boundary();
        }

        void Boundary() {
            Vector2 temp = transform.position;
            if (temp.x < -1.25f) //for left side boundary
            {
                temp.x = -1.25f;
                transform.position = temp;
            }

            if (temp.x > 1.25f) //for right side boundary
            {
                temp.x = 1.25f;
                transform.position = temp;
            }

            if (temp.y < -2.23f) //for bottom side boundary
            {
                temp.y = -2.23f;
                transform.position = temp;
            }

            if (temp.y > 2.23f) //for top side boundary
            {
                temp.y = 2.23f;
                transform.position = temp;
            }
        }

        //function for movement to left
        public void Left()
        {
            rb.velocity = new Vector2((-1) * sideSpeed, 0);
            /*
            Vector2 temp = transform.position;
            temp.x -= 1;
            transform.position = temp;
            */
        }

        //function for movement to right
        public void Right()
        {
            rb.velocity = new Vector2(sideSpeed, 0);
            /*
            Vector2 temp = transform.position;
            temp.x += 1;
            transform.position = temp;
            */
        }

        //function to go Up
        public void Up()
        {
            rb.velocity = new Vector2(0, speed * Time.deltaTime);
            carMoveUD.Play();//sound for car driving
        }

        //function to go Down
        public void Down()
        {
            rb.velocity = new Vector2(0, (-1)*speed * Time.deltaTime);
            carMoveUD.Play();//sound for car driving
        }

        //function to Stop
        public void Stop()
        {
            carMoveUD.Stop();//stop the sound for car when stopped
            rb.velocity = new Vector2(0, 0);
        }
    }
}
