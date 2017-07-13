using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Jogo_de_Dados
{
    public class Menu : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Dado dado;
        private float time;

        public Menu()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            time = 1;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("SpriteSheets/dados2");

            dado = new Dado(texture, 1, 6);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (time >= 0)
            {
                dado.Update(gameTime);
                time -= dt;
            }
            
            if(time <= 0)
            {
                Random rdn = new Random();
                int r = rdn.Next(0, 5);
                dado.Update2(r);

                
                
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //spriteBatch.Begin();

            dado.Draw(spriteBatch, new Vector2(200, 200));


            //spriteBatch.End();
            base.Draw(gameTime);
        }

        private void retornaValorDado()
        {
            Console.WriteLine("Valor da Face: " + (dado.getValorFace() + 1));
        }
    }
}
