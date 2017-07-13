using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jogo_de_Dados
{
    public class SpriteSheet
    {

        private Texture2D _tex { get; set; }
        private int _colunas { get; set; }
        private int _linhas { get; set; }
        private static int _spriteLargura { get; set; }
        private static int _spriteAltura { get; set; }
        private int _frameInicial { get; set; }
        private int _frameFinal { get; set; }
        private int _animTotalFrames { get; set; }
        private float _animFrame { get; set; }
        private float _animVelociade { get; set; }



        public SpriteSheet(Texture2D t, int col, int lin)
        {
            _animFrame = 0f;
            _animVelociade = 0f;

            _tex = t;
            _colunas = col;
            _linhas = lin;

            _spriteLargura = _tex.Width / _colunas;
            _spriteAltura = _tex.Height / _linhas; 
        }

        public Rectangle GetSourceRectangle(int frame)
        {
            int x = (frame % this._colunas) * _spriteLargura;
            int y = (frame / this._colunas) * _spriteAltura;

            return new Rectangle(x, y, _spriteLargura, _spriteAltura);
        }

        public void PlayAnim(int frameIni, int frameFim, float animVel)
        {
            _animFrame = (float)frameIni;
            _frameInicial = frameIni;
            _frameFinal = frameFim;
            _animVelociade = animVel;

            _animTotalFrames = frameFim - frameIni + 1;
        }

        public void UpdateAnim(float dt)
        {
            _animFrame -= _frameInicial;

            _animFrame += dt * _animVelociade;

            _animFrame = _animFrame % _animTotalFrames;
            if (_animFrame < 0f)
                _animFrame += _animTotalFrames;

            _animFrame += _frameInicial;
        }

        public Texture2D GetTex()
        {
            return _tex;
        }

        public float GetAnimFrame()
        {
            return _animFrame;
        }

        public static int GetSpriteLargura()
        {
            return _spriteLargura;
        }

        public static int GetSpriteAltura()
        {
            return _spriteAltura;
        }

    }
}
