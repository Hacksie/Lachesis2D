using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] bool transitionDown;
        [SerializeField] GameObject level1 = null;
        [SerializeField] GameObject level2 = null;
        // Start is called before the first frame update

        public void TransitionToLevel1()
        {
            level1.SetActive(true);
            level2.SetActive(false);
        }

        public void TransitionToLevel2()
        {
            level1.SetActive(false);
            level2.SetActive(true);
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
