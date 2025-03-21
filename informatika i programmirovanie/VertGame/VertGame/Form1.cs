using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace VertGame
{
    public partial class Form1 : Form
    {
        // Ресурсы
        Bitmap grass = Properties.Resources.gtrava; Bitmap sun = Properties.Resources.sun; Bitmap palma = Properties.Resources.palm1;
        Bitmap mountains = Properties.Resources.mountains; Bitmap pesok1 = Properties.Resources.pesok1; Bitmap pesok2 = Properties.Resources.pesok2;
        Bitmap moon = Properties.Resources.moon1;
        // Враги
        List<Enemy> enemies = new List<Enemy>();
        EnemySpawner enemySpawner;
        Bitmap[] vert1Right = { Properties.Resources.vert1__1_, Properties.Resources.vert1__2_ };
        Bitmap[] vert1Left = { Properties.Resources.vert1__3_, Properties.Resources.vert1__4_ };
        Bitmap[] vert3Right = { Properties.Resources.vert3__1_, Properties.Resources.vert3__2_ };
        Bitmap[] vert3Left = { Properties.Resources.vert3__3_, Properties.Resources.vert3__4_ };
        // Игрок
        Helicopter helicopter3;
        Bitmap[] vert2Right = { Properties.Resources.vert2__1_, Properties.Resources.vert2__2_ }; Bitmap[] vert2Left = { Properties.Resources.vert2__3_, Properties.Resources.vert2__4_ };
        int playerStartX, playerStartY;
        // Ракеты
        List<Rocket> rockets = new List<Rocket>();
        Bitmap[] rocketSpritesRight = { Properties.Resources.rocket1__1_, Properties.Resources.rocket1__2_, Properties.Resources.rocket1__3_, Properties.Resources.rocket1__4_ };
        Bitmap[] rocketSpritesLeft = { Properties.Resources.rocket2__1_, Properties.Resources.rocket2__2_, Properties.Resources.rocket2__3_, Properties.Resources.rocket2__4_ };
        // Взрывы
        Bitmap[] explosionSprites2 = new Bitmap[30] { Properties.Resources.ex2__1_, Properties.Resources.ex2__2_, Properties.Resources.ex2__3_, Properties.Resources.ex2__4_, Properties.Resources.ex2__5_, Properties.Resources.ex2__6_, Properties.Resources.ex2__7_, Properties.Resources.ex2__8_, Properties.Resources.ex2__9_, Properties.Resources.ex2__10_, Properties.Resources.ex2__11_, Properties.Resources.ex2__12_, Properties.Resources.ex2__13_, Properties.Resources.ex2__14_, Properties.Resources.ex2__15_, Properties.Resources.ex2__16_, Properties.Resources.ex2__17_, Properties.Resources.ex2__18_, Properties.Resources.ex2__19_, Properties.Resources.ex2__20_, Properties.Resources.ex2__21_, Properties.Resources.ex2__22_, Properties.Resources.ex2__23_, Properties.Resources.ex2__24_, Properties.Resources.ex2__25_, Properties.Resources.ex2__26_, Properties.Resources.ex2__27_, Properties.Resources.ex2__28_, Properties.Resources.ex2__29_, Properties.Resources.ex2__30_ };
        Bitmap[] smokeSprites = new Bitmap[9] { Properties.Resources.ex2__22_, Properties.Resources.ex2__23_, Properties.Resources.ex2__24_, Properties.Resources.ex2__25_, Properties.Resources.ex2__26_, Properties.Resources.ex2__27_, Properties.Resources.ex2__28_, Properties.Resources.ex2__29_, Properties.Resources.ex2__30_ };
        Bitmap[] airExplosionSprites = new Bitmap[19] { Properties.Resources.ex1__6_, Properties.Resources.ex1__7_, Properties.Resources.ex1__8_, Properties.Resources.ex1__9_, Properties.Resources.ex1__10_, Properties.Resources.ex1__11_, Properties.Resources.ex1__12_, Properties.Resources.ex1__13_, Properties.Resources.ex1__14_, Properties.Resources.ex1__15_, Properties.Resources.ex1__16_, Properties.Resources.ex1__17_, Properties.Resources.ex1__18_, Properties.Resources.ex1__19_, Properties.Resources.ex1__20_, Properties.Resources.ex1__21_, Properties.Resources.ex1__22_, Properties.Resources.ex1__23_, Properties.Resources.ex1__24_ };
        // Игра
        int score = 0;
        int level = 1;
        int enemiesDefeated = 0;
        bool gameOver = false;
        bool gameWon = false; // Флаг победы
        private Button restartButton; // Кнопка перезапуска
        private Button pauseButton; // кнопка паузы
        private Button exitButton; // кнопка выхода
        private bool isPaused = false;
        private Point pauseButtonDefaultLocation; // Сохраняем изначальное положение кнопки паузы
        // Интервал между выстрелами
        private DateTime lastShotTime = DateTime.MinValue;
        private TimeSpan shotInterval = TimeSpan.FromSeconds(1);
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            playerStartX = Width / 2;
            playerStartY = Height / 2;
            helicopter3 = new Helicopter(vert2Right, playerStartX, playerStartY, explosionSprites2);  // Начинаем с видом вправо
            helicopter3.MaxHeight = Height / 3;
            // Инициализация EnemySpawner
            enemySpawner = new EnemySpawner(vert1Right, vert1Left, vert3Right, vert3Left, airExplosionSprites, explosionSprites2, smokeSprites);
            restartButton = new Button // Кнопка перезапуска
            {
                Text = "Restart",
                Location = new Point(Width / 2 - 50, Height / 2 + 20),
                Size = new Size(100, 30),
                Font = new Font("Arial", 14),
                Visible = false
            };
            restartButton.Click += RestartButton_Click;
            Controls.Add(restartButton);
            exitButton = new Button // Кнопка выхода из игры
            {
                Text = "Exit",
                Location = new Point(Width / 2 - 50, Height / 2 + 60),
                Size = new Size(100, 30),
                Font = new Font("Arial", 14),
                Visible = false,
                TabStop = false
            };
            exitButton.Click += ExitButton_Click;
            Controls.Add(exitButton);
            pauseButton = new Button // Кнопка паузы
            {
                Text = "Pause",
                Location = new Point(Width - 120, 10),
                Size = new Size(110, 30),
                Cursor = Cursors.Hand,
                Font = new Font("Ravie", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Visible = true,
                TabStop = false
            };
            pauseButton.Click += PauseButton_Click;
            Controls.Add(pauseButton);
            pauseButtonDefaultLocation = pauseButton.Location; // Сохраняем изначальное положение кнопки паузы
            StartNewGame();
            // Управление
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            KeyPreview = true;
            timer1.Enabled = true;
        }
        void StartNewGame() // Начать новую игру
        {
            gameOver = false;
            gameWon = false; // Сброс флага победы
            score = 0;
            level = 1;
            enemiesDefeated = 0;
            lastShotTime = DateTime.MinValue; // Сбрасываем время последнего выстрела
            isPaused = false; // Сбрасываем флаг паузы
            pauseButton.Text = "Pause"; // Меняем текст кнопки паузы
            exitButton.Visible = false; // Скрываем кнопку выхода
            pauseButton.Location = pauseButtonDefaultLocation; // Возвращаем в исходное положение
            // Вертолёт игрока
            helicopter3.X = playerStartX;
            helicopter3.Y = playerStartY;
            helicopter3.IsDead = false;
            helicopter3.IsExploding = false;
            helicopter3.ExplosionFrame = 0;
            // Враги
            enemies.Clear();
            enemies = enemySpawner.SpawnEnemies(level + 1, Width); // регулировка врагов
            // Ракеты
            rockets.Clear();
            // Кнопка перезапуска
            restartButton.Visible = false; // Скрываем кнопку
            this.Focus(); // Возвращаем фокус на форму
        }
        void timer1_Tick(object sender, EventArgs e) // Обновление игры
        {
            if (gameOver || isPaused) return;
            for (int i = 0; i < enemies.Count; i++) // Движение врагов
            {
                Enemy enemy = enemies[i];
                enemy.Update();
                if (!enemy.IsAlive && !enemy.IsFalling && !enemy.IsExploding && !enemy.IsCollisionExploding)
                {
                    enemies.RemoveAt(i);
                    i--; // Важно: уменьшаем индекс после удаления элемента
                    enemiesDefeated++;
                    continue;
                }
            }
            foreach (var rocket in rockets) // Движение ракет
            {
                rocket.Update();
                if (rocket.X > Width || rocket.X < 0) // Если ракета улетела за экран
                    rocket.IsActive = false;
            }
            rockets.RemoveAll(rocket => !rocket.IsActive); // Удаляем неактивные ракеты
            if (!helicopter3.IsDead) // Движение игрока
            {
                helicopter3.Update();
                helicopter3.X = Math.Max(0, Math.Min(helicopter3.X, Width - helicopter3.GetWidth())); // Ограничение движения
                helicopter3.Y = Math.Max(0, Math.Min(helicopter3.Y, Height - helicopter3.GetHeight())); // Ограничение движения
            }
            CheckCollisions();
            // Проверка перехода на новый уровень ИЛИ победы
            if (enemiesDefeated >= level + 1 && enemies.Count == 0)  // Проверяем, все ли враги убиты (и удалены)
            {
                if (level < 5)
                {
                    level++;
                    enemiesDefeated = 0;
                    enemies = enemySpawner.SpawnEnemies(level + 1, Width); // регулировка врагов 
                    helicopter3.X = playerStartX;
                    helicopter3.Y = playerStartY;
                }
                else
                {
                    gameOver = true; // Победа!
                    gameWon = true; // Устанавливаем флаг победы
                    restartButton.Visible = true;
                }
            }
            Invalidate();
        }
        void CheckCollisions() // Проверка столкновений
        {
            for (int i = 0; i < enemies.Count; i++) // Столкновение игрока с врагами
            {
                if (enemies[i].IsAlive && helicopter3.GetBounds().IntersectsWith(enemies[i].GetBounds()))
                {
                    helicopter3.Explode(explosionSprites2); // Вертолет игрока взрывается
                    enemies[i].ExplodeInAir(); // Враг взрывается
                    gameOver = true;
                    restartButton.Visible = true;
                    return;
                }
            }
            for (int i = 0; i < rockets.Count; i++) // Попадание ракет во врагам
            {
                if (!rockets[i].IsActive) continue;
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (enemies[j].IsAlive && !enemies[j].IsFalling && !enemies[j].IsExploding && !enemies[j].IsCollisionExploding && rockets[i].GetBounds().IntersectsWith(enemies[j].GetBounds()))
                    {
                        // Ракета попала во врага
                        rockets[i].IsActive = false;
                        Random random = new Random();
                        // 50/50 шанс взорваться в воздухе или начать падение
                        if (random.Next(2) == 0)
                        {
                            // Используем "воздушный" взрыв, как при столкновении
                            enemies[j].ExplodeInAir();
                        }
                        else
                        {
                            // Используем "падение"
                            enemies[j].StartFalling();
                        }
                        score += 10; // Увеличиваем score
                        enemiesDefeated++; // Увеличиваем score
                        break;
                    }
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(0, 204, 255));
            DrawBackground(g, g); // Рисуем фон в зависимости от уровня
            foreach (var enemy in enemies) /* Враги*/ {enemy.Draw(g);}
            foreach (var rocket in rockets) // Ракеты
            {
                if (rocket.IsActive)
                    rocket.Draw(g);
            }
            if (!helicopter3.IsDead) /* Игрок*/ {helicopter3.Draw(g);}
            if (!isPaused) // Вывод информации об игре
            {
                g.DrawString($"Score: {score}  Level: {level}", new Font("Arial", 16), Brushes.Black, 10, 10);
                g.DrawString($"Pause", new Font("Ravie", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, Width - 120, 10);
            }
            if (isPaused) /* Пауза*/ {DrawPauseOverlay(g);}
            if (gameOver) // Сообщение о победе
            {
                string message = gameWon ? $"YOU WON! Score: {score}" : $"GAME OVER! Score: {score}";  //Вывод сообщения в зависимости от того выйграл или проиграл
                g.DrawString(message, new Font("Arial", 24), Brushes.Red, Width / 2 - 150, Height / 2 - 50);
                restartButton.Visible = true;
                exitButton.Visible = true;
            }
        }
        private void DrawPauseOverlay(Graphics g) /* Отрисовка паузы*/{g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), 0, 0, Width, Height);}
        void DrawBackground(Graphics g, Graphics gr) // Отрисовка фона в зависимости от уровня
        {
            switch (level)
            {
                case 1:
                    g.DrawImage(sun, 0, 0);
                    g.DrawImage(palma, Width - palma.Width - 100, Height - palma.Height - 130);
                    for (int i = 0; i <= Width / grass.Width; i++)
                        g.DrawImage(grass, i * grass.Width, Height - 70);
                break;
                case 2:
                    g.DrawImage(sun, 150, -65);
                    g.DrawImage(pesok1, -Width / 2, Height - 200, Width * 2, 200);  // Увеличиваем ширину и поднимаем песок
                break;
                case 3:
                    g.DrawImage(sun, 400, -65);
                    g.DrawImage(pesok2, 0, Height - 150, Width, 150);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(48, 0, 0, 0)), 0, 0, Width, Height);  // Вечерний оттенок
                break;
                case 4:
                    g.DrawImage(mountains, 0, 0, Width, Height);
                    g.DrawImage(sun, 650, 25);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(75, 0, 0, 0)), 0, 0, Width, Height);  // Вечерний оттенок
                break;
                case 5:
                    g.DrawImage(mountains, 0, 0, Width, Height);
                    g.DrawImage(moon, 50, -30);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(130, 0, 0, 0)), 0, 0, Width, Height);
                break;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e) // Обработка нажатий клавиш управления
        {
            switch (e.KeyCode)
            {
                case Keys.W: helicopter3.MoveUp = true; break;
                case Keys.S: helicopter3.MoveDown = true; break;
                case Keys.A:
                    helicopter3.MoveLeft = true;
                    helicopter3.SetSprites(vert2Left); // Поворачиваем влево
                    helicopter3.CurrentRocketSprites = rocketSpritesLeft;  //Меняем спрайты для ракет
                break;
                case Keys.D:
                    helicopter3.MoveRight = true;
                    helicopter3.SetSprites(vert2Right); // Поворачиваем вправо
                    helicopter3.CurrentRocketSprites = rocketSpritesRight; //Меняем спрайты для ракет
                break;
                case Keys.Space:  // Стрельба
                    ShootRocket();
                break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e) // Обработка отпускания клавиш управления
        {
            switch (e.KeyCode)
            {
                case Keys.W: helicopter3.MoveUp = false; break;
                case Keys.S: helicopter3.MoveDown = false; break;
                case Keys.A: helicopter3.MoveLeft = false; break;
                case Keys.D: helicopter3.MoveRight = false; break;
            }
        }
        void ShootRocket() // Стрельба
        {
            if (DateTime.Now - lastShotTime >= shotInterval && !gameOver && !isPaused) // Проверяем интервал
            {
                Rocket newRocket = new Rocket(helicopter3.CurrentRocketSprites, helicopter3.X, helicopter3.Y + helicopter3.GetHeight() / 2);
                newRocket.X = helicopter3.X + (helicopter3.CurrentSprites == vert2Right ? helicopter3.GetWidth() : -newRocket.GetWidth()); //позиционирование
                newRocket.Y = helicopter3.Y + (helicopter3.GetHeight() / 4);
                newRocket.IsFacingRight = helicopter3.CurrentSprites == vert2Right; // Проверяем направление
                rockets.Add(newRocket);
                lastShotTime = DateTime.Now; // Обновляем время последнего выстрела
            }
        }
        private void RestartButton_Click(object sender, EventArgs e){StartNewGame(); } // Обработчик нажатия кнопки перезапуска
        private void PauseButton_Click(object sender, EventArgs e) // Обработчик нажатия кнопки паузы
        {
            isPaused = !isPaused;
            pauseButton.Text = isPaused ? "Resume" : "Pause";
            exitButton.Visible = isPaused; // Показывать кнопку выхода только при паузе
            if (isPaused) // Перенос кнопки в центр после того, как нажата пауза
            {pauseButton.Location = new Point(Width / 2 - pauseButton.Width / 2, Height / 2 - 100);}
            else{pauseButton.Location = pauseButtonDefaultLocation;}
            // Останавливаем/запускаем таймер в зависимости от состояния паузы
            if (isPaused){timer1.Stop();}
            else{timer1.Start();}
            this.Focus(); //Возвращаем фокус
        }
        private void ExitButton_Click(object sender, EventArgs e) /*Обработчик нажатия кнопки выхода*/ {Application.Exit();}
    }
}