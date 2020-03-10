using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class AreaTrigger : MonoBehaviour
    {
        [SerializeField] private EnvironmentManager environment;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
        }


        //    private void OnTriggerStay2D(Collider2D collision)
        //{
        //    Debug.Log(collision.gameObject.name);
        //}
    }
}