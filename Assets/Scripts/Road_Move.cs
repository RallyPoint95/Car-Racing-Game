using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Com.Vishal.Car_Racing_game
{
    public class Road_Move : MonoBehaviour
    {
        private MeshRenderer mesh;
        public float speed;
        // Start is called before the first frame update
        void Start()
        {
            mesh = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            Scroll();
        }

        void Scroll() {
            speed += 0.001f * Time.deltaTime;
            Vector2 offset = new Vector2(0, speed * Time.time);
            mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
    }
}
