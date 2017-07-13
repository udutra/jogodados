using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jogo_de_Dados
{
    class Dado
    {
        private Texture2D Texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame { get; set; }
        private int totalFrames { get; set; }

        //Slow down frame animation
        private int timeSinceLastFrame { get; set; }
        private int millisecondsPerFrame { get; set; }

        public Dado()
        {
            currentFrame = 0;
            totalFrames = 0;
        }

        public Dado(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 50;
        }
        
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if(timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                
                //increment current frame
                currentFrame++;
                timeSinceLastFrame = 0;
                if(currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {

        }




    }
}