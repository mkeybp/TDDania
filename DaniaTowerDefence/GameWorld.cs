using DaniaTowerDefence;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DaniaTowerDefence
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> gameObjectsToAdd = new List<GameObject>();
        public List<GameObject> gameObjectsToRemove = new List<GameObject>();
        public List<Student> students = new List<Student>();
        public Student student;
        public Tower tower;
        public Bullet bullet;
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
        Grid gr = new Grid();

        public Vector2 studentPos;

        public Location current;
        public int tileSize = 32;
        public Vector2 position = Vector2.Zero;
        public Texture2D gridTexture;
        private Texture2D studentTex;


        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 500;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();

            gr.Pathfinding();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }

            gridTexture = Content.Load<Texture2D>("tile1");
            studentTex = Content.Load<Texture2D>("student");

            Texture2D towerSprite = Content.Load<Texture2D>("Tower_aim");
            Texture2D studentSprite = Content.Load<Texture2D>("milo_front");
            Texture2D bulletSprite = Content.Load<Texture2D>("Healing_test");
            gameObjects.Add(tower = new Tower(towerSprite));
            gameObjects.Add(student = new Student(studentSprite));



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>      
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }
            if (tower.Target == null)
            {
                students.Add(student);

                tower.GetClosestStudent(students);
            }
            foreach(Student student in students)
            {
                student.Update(gameTime);
            }
            student.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            spriteBatch.Begin(SpriteSortMode.BackToFront);
            // TODO: Add your drawing code here
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            for (int i = 0; i <= Grid.grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Grid.grid.GetUpperBound(1); j++)
                {
                    int textureId = Grid.grid[i, j];
                    Vector2 texturePosition = new Vector2(i * tileSize, j * tileSize) + position;

                    // Should be: textureId != "X"
                    if (textureId == 1)
                    {

                      
                        spriteBatch.Draw(gridTexture, texturePosition, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 1f);
                    }



                    spriteBatch.Draw(studentTex, gr.currentPosition * 32, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 1f);

                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
