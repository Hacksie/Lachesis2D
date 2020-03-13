using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Game : MonoBehaviour
    {
        public static Game instance;

        [SerializeField] private GameState state = new GameState();

        Game()
        {
            instance = this;
        }

        public GameState State() => state;

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

        public bool IsPlaying()
        {
            return state.gameState == GameStateEnum.Playing;
        }

        public void SetGameState(GameStateEnum gameState)
        {
            this.state.gameState = gameState;

        }

        public void GameOverSuffocate()
        {
            SetGameState(GameStateEnum.DeadAir);
        }

        // Update is called once per frame
        void Update()
        {
            switch(state.gameState)
            {
                case GameStateEnum.Playing:
                    UpdateSpacePosition();

                    break;
            }
            
        }

        void UpdateSpacePosition()
        {
            state.spacePosition.y += Time.deltaTime;
        }
    }
}