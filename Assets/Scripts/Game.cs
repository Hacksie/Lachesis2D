using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Game : MonoBehaviour
    {
        [SerializeField] GameState state = new GameState();


        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            InitializeGame();
        }

        void InitializeGame()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}