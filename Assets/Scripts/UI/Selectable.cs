using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HackedDesign
{
    public class Selectable : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public Description description = null;

        [SerializeField] private UnityEvent selectEvent = null;

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