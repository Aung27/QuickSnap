using System;
using SwinGameSDK;
using CardGames.GameLogic;

namespace CardGames
{
    public class SnapGame
    {
        public static void LoadResources()
        {
            Bitmap cards;
            cards = SwinGame.LoadBitmapNamed("Cards", "Cards.png");
            SwinGame.BitmapSetCellDetails(cards, 82, 110, 13, 5, 53);
        }

        /// <summary>
        /// Respond to the user input.
        /// </summary>
        private static void HandleUserInput(Snap myGame)
        {
            // Fetch the next batch of UI interaction
            SwinGame.ProcessEvents();

            // Press Space to START the game
            if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
            {
                myGame.Start();
            }
        }

        /// <summary>
        /// Draws the game to the Window.
        /// </summary>
        private static void DrawGame(Snap myGame)
        {
            SwinGame.ClearScreen(Color.White);

            // Draw the top card
            Card top = myGame.TopCard;

            if (top != null)
            {
                SwinGame.DrawText(
                    "Top Card is " + top.ToString(),
                    Color.RoyalBlue,
                    0,
                    20
                );

                SwinGame.DrawText(
                    "Player 1 score: " + myGame.Score(0),
                    Color.RoyalBlue,
                    0,
                    30
                );

                SwinGame.DrawText(
                    "Player 2 score: " + myGame.Score(1),
                    Color.RoyalBlue,
                    0,
                    40
                );

                SwinGame.DrawCell(
                    SwinGame.BitmapNamed("Cards"),
                    top.CardIndex,
                    350,
                    50
                );
            }
            else
            {
                SwinGame.DrawText(
                    "No card played yet...",
                    Color.RoyalBlue,
                    0,
                    20
                );
            }

            // Draw the back of the cards (deck)
            SwinGame.DrawCell(
                SwinGame.BitmapNamed("Cards"),
                52,
                160,
                50
            );

            // Draw onto the screen
            SwinGame.RefreshScreen(60);
        }

        /// <summary>
        /// Updates the game.
        /// </summary>
        private static void UpdateGame(Snap myGame)
        {
            myGame.Update();
        }

        public static void Main()
        {
            // Open the game window
            SwinGame.OpenGraphicsWindow("Snap!", 860, 500);

            // Load resources
            LoadResources();

            // Create the game
            Snap myGame = new Snap();

            // Run the game loop
            while (!SwinGame.WindowCloseRequested())
            {
                HandleUserInput(myGame);
                DrawGame(myGame);
                UpdateGame(myGame);
            }
        }
    }
}