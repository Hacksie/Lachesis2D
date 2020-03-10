using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Game : MonoBehaviour
    {
        public static Game instance;

        [SerializeField] public GameState state = new GameState();

        Game()
        {
            instance = this;
        }


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
            state.spacePosition.y += Time.deltaTime;
        }
    }
}