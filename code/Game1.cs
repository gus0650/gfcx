using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace gfcx;

public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch sprites1;

	Texture2D sprite;
    SpriteFont bfont;

	SoundEffect sound;
	Song song;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        sprites1 = new SpriteBatch(GraphicsDevice);

		//set up display
		var fullscreeen = false;
		if (fullscreeen) {
			graphics.HardwareModeSwitch = true;
			graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
			graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
			graphics.IsFullScreen = true;
			graphics.ApplyChanges();
		}

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here

		sprite = Content.Load<Texture2D>("braid_char");

		bfont = Content.Load<SpriteFont>("fontxna");

		song = Content.Load<Song>("1980");

		sound = Content.Load<SoundEffect>("sound");

		base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

			KeyboardState key = Keyboard.GetState();

            // press space to play a sound
            if (key.IsKeyDown(Keys.S)) sound.Play();

            if (key.IsKeyDown(Keys.M)) 	MediaPlayer.Play(song);

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

		sprites1.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);
		sprites1.DrawString(bfont, "test program - s sound, m music", new Vector2(100, 100), Color.White);
		//sprites1.Draw(sprite, new Vector2(100, 150), Color.White);
		sprites1.End();

		Rectangle sourceRectangle = new Rectangle(0, 0, 48, 64);
		Rectangle destinationRectangle = new Rectangle(100, 150, 48, 64);
		Vector2 origin = new Vector2(0, 0);
		float rotation = 0.0f;
		Vector2 scale = new Vector2(1.0f, 1.0f);
		SpriteEffects effects = SpriteEffects.None;
		float layerDepth = 0.0f;

		sprites1.Begin();
		sprites1.Draw(sprite, destinationRectangle, sourceRectangle, Color.White, rotation, origin, effects, layerDepth);
		sprites1.End();


		// TODO draw a tilemap

        base.Draw(gameTime);
    }
}
