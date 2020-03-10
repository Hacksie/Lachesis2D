using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Parallax : MonoBehaviour
    {

        private Vector2 bounds, startpos;

        [SerializeField]
        private float parallaxEffect = 0.0f;

        [SerializeField]
        //private GameState state;

        void Start()
        {

            startpos = transform.position;
            bounds = GetComponent<SpriteRenderer>().bounds.size;
        }

        void FixedUpdate()
        {
            
            Vector2 temp = (Game.instance.state.spacePosition * (1 - parallaxEffect));
            Vector2 dist = Game.instance.state.spacePosition * parallaxEffect;

            transform.position = startpos - dist;

            if (temp.x > (startpos.x + bounds.x))
                startpos.x += bounds.x;
            if (temp.x < (startpos.x - bounds.x))
                startpos.x -= bounds.x;
            if (temp.y > (startpos.y + bounds.y))
                startpos.y += bounds.y;
            if (temp.y < (startpos.y - bounds.y))
                startpos.y -= bounds.y;
        }
    }

}