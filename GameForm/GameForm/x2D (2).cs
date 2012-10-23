using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WF = System.Windows.Forms;
using prime2d = TestXna.Primitives2d; 


namespace GameForm
{
    public class x2D : Game
    {
        private WF.Control _container;
        private prime2d _prime2d;
        private xWindow _xWindow;
        private Texture2D MySprite;
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private Vector2 position = new Vector2(150, 200);
        public int sizeSpriteNew, sizeSprite = 600;
        public x2D(WF.Control p_container)
        {
            _container = p_container;
            _xWindow = (xWindow)p_container.FindForm();

            _container.Resize += new EventHandler(_container_Resize);
            _container.SizeChanged += new EventHandler(_container_Resize);
            WF.Control.FromHandle(this.Window.Handle).VisibleChanged += new EventHandler(x2D_VisibleChanged);

            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1;
            _graphics.PreferredBackBufferHeight = 1;

            _graphics.PreparingDeviceSettings +=
                new EventHandler<PreparingDeviceSettingsEventArgs>(_graphics_PreparingDeviceSettings);

            Content.RootDirectory = "Content";
            Mouse.WindowHandle = _container.Handle;

            this._graphics.SynchronizeWithVerticalRetrace = true;
            this.IsFixedTimeStep = false;
        }

        #region Container Events

        private void _graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = _container.Handle;
        }

        private void x2D_VisibleChanged(object sender, EventArgs e)
        {
            if (WF.Control.FromHandle(Window.Handle).Visible)
                WF.Control.FromHandle(Window.Handle).Visible = false;
        }

        private void _container_Resize(object sender, EventArgs e)
        {
            int w = _container.ClientSize.Width;
            int h = _container.ClientSize.Height;

            if (_graphics.GraphicsDevice == null || w == 0 || h == 0) return;

            PresentationParameters pp = _graphics.GraphicsDevice.PresentationParameters;
            pp.BackBufferWidth = w;
            pp.BackBufferHeight = h;

            _graphics.GraphicsDevice.Reset(pp);
        }

        #endregion

        #region Initialize, Content

        protected override void Initialize()
        {
            base.Initialize();
            _container_Resize(null, EventArgs.Empty);
        }

        protected override void LoadContent()
        {
               
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MySprite = Content.Load<Texture2D>("board");
            _prime2d = new prime2d(GraphicsDevice,_spriteBatch);
        }

        protected override void UnloadContent() { }

        #endregion


        protected override void Update(GameTime p_gameTime)
        {
            base.Update(p_gameTime);
        }
             protected override void Draw(GameTime p_gameTime)
        {
                 int x,y,cx=0,cy=0;
            x=_container.ClientSize.Width;
                 y= _container.ClientSize.Height;
            //_container.ClientSize.Width != 
            GraphicsDevice.Clear(Color.CornflowerBlue);
          //  Vector3 vecScale = new Vector3(2, 2, 2);
           // Matrix matrixScale = Matrix.CreateScale(vecScale);
           
                 if (x > y)
            {
                
                cx = x-sizeSprite;
                cy = y-sizeSprite;
                if (cx < cy) sizeSpriteNew = sizeSprite + cx;
                else sizeSpriteNew = sizeSprite + cy;
            }
            else if (y > x) {
                cx = x - sizeSprite;
                cy = y - sizeSprite;
                if (cy < cx) sizeSpriteNew = sizeSprite + cy;
                else sizeSpriteNew = sizeSprite + cx;
            }
            
            
            //if ((_container.ClientSize.Width<_container.ClientSize.Height)|(_container.ClientSize.Height<_container.ClientSize.Width)){
                
           // }
                
            _spriteBatch.Begin();
           //_spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState, matrixScale);
           // _spriteBatch.Draw(MySprite, new Rectangle(20, 20, 536,351), Color.White);
            _spriteBatch.Draw(MySprite, new Rectangle(0,0, sizeSpriteNew, sizeSpriteNew), Color.White);
            _prime2d.DrawLine(0, 0, 600, 600, Color.Black);
            //_prime2d.DrawLine(1, 1, 1, 600, Color.Black);
            _spriteBatch.End();
          

            base.Draw(p_gameTime);

        }
    }
}
