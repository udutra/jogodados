using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        private int valorFace;

       public Dado(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 50;
            valorFace = 0;
        }
        
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if(timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                
                //increment current frame
                currentFrame++;
                valorFace++;
                timeSinceLastFrame = 0;
                if(currentFrame == totalFrames)
                {
                    currentFrame = 0;
                    valorFace = 0;
                }
            }
        }

        public void Update2(int sort)
        {
            if(sort == currentFrame)
            {

            }
            else if (sort > currentFrame)
            {
                currentFrame++;
            }
            else
            {
                currentFrame--;
            }
        }



        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spritebatch.Begin();
            spritebatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spritebatch.End();
        }

        public int getValorFace()
        {
            return valorFace;
        }


    }
}