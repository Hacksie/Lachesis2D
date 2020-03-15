using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject doorSprite;

    [Header("State")]
    [SerializeField] private bool closed = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        closed = !closed;
        doorSprite.SetActive(closed);
    }
}
