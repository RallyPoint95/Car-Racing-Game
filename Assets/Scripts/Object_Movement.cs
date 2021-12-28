using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Vishal.Car_Racing_game
{
    public class Object_Movement : MonoBehaviour
    {
        public float speed;
        public float maxSpeed;
        // Start is called before the first frame update
        void Start()
        {
            speed += 0.003f * Time.time;//incresing the object speed
            if (speed >= maxSpeed)//if speed reachs maximum speed then stop increasing the speed
            {
                speed = maxSpeed;
            }
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        //function for movement of other objects 
        public void Move()
        {
            Vector2 temp = transform.position;
            temp.y -= speed * Time.deltaTime;//if other objects reaches its maximum position speed of that object decreases
            transform.position = temp;
        }
    }
}
