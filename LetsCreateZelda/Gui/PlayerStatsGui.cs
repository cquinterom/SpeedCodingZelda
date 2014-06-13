﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Gui
{
    class PlayerStatsGui
    {
        private Texture2D _tempTexture;
        private Texture2D _rupeeTexture;
        private Texture2D _heartTexture;
        private Texture2D _containerTexture;
        private Texture2D _backgroundTexture;
        private SpriteFont _font; 
        private Stats _stats;
        private int _lessY;  
        

        public PlayerStatsGui(Stats stats, WindowPosition windowPosition = WindowPosition.Down)
        {
            _stats = stats;
            if (windowPosition == WindowPosition.Up)
                _lessY = 128;
        }

        public void LoadContent(ContentManager content)
        {
            _rupeeTexture = content.Load<Texture2D>("rupee_gui");
            _heartTexture = content.Load<Texture2D>("heart_gui");
            _containerTexture = content.Load<Texture2D>("container_gui");
            _font = content.Load<SpriteFont>("Font_GUI");
            _tempTexture = content.Load<Texture2D>("boomerang_gui");
            _backgroundTexture = content.Load<Texture2D>("white_background");
        }

        public void Update(Stats stats)
        {
            _stats = stats; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_stats == null)
                return; 

            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 128 - _lessY, 160, 16), new Color(245, 245, 135));

            spriteBatch.Draw(_containerTexture, new Rectangle(9, 130 - _lessY, 30, 12), Color.Black);
            spriteBatch.DrawString(_font, "B", new Vector2(1, 129 - _lessY), Color.Black);
            spriteBatch.Draw(_tempTexture, new Rectangle(12, 131 - _lessY, 10, 10), Color.White);

            spriteBatch.Draw(_containerTexture, new Rectangle(47, 130 - _lessY, 30, 12), Color.Black);
            spriteBatch.DrawString(_font, "A", new Vector2(40, 129 - _lessY), Color.Black);

            spriteBatch.Draw(_rupeeTexture, new Rectangle(80, 130 - _lessY, 9, 9), Color.White);
            spriteBatch.DrawString(_font, "999", new Vector2(80, 135 - _lessY), Color.Black);

            for (int n = 0; n < _stats.CurrentHealth; n++)
            {
                spriteBatch.Draw(_heartTexture, new Rectangle(100 + n * 10, 130 - _lessY, 9, 9), Color.White);
            }
        }


    }
}