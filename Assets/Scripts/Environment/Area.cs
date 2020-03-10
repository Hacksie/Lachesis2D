using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Area : MonoBehaviour
    {
        [SerializeField] private EnvironmentManager environment = null;

        [SerializeField] public string title;
        [SerializeField] public AreaState state = new AreaState();


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                environment.AddCurrentArea(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                environment.RemoveCurrentArea(this);
            }
        }

    }

}