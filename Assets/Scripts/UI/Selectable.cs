using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HackedDesign
{
    public class Selectable : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public Description description;

        [SerializeField] private UnityEvent selectEvent;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Select()
        {
            selectEvent.Invoke();
        }
    }
}