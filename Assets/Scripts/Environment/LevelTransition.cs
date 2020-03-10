using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] bool transitionDown = false;
        [SerializeField] EnvironmentManager environment = null;

        // Start is called before the first frame update

        public void TransitionToLevel1()
        {
            environment.TransitionUp();
        }

        public void TransitionToLevel2()
        {
            environment.TransitionDown();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (transitionDown)
            {
                TransitionToLevel2();
            }
            else
            {
                TransitionToLevel1();
            }
        }
    }
}
