using System;
using System.Drawing;
using System.Diagnostics;
namespace VertGame
{
    class Enemy
    {
        Bitmap[] sprites;
        Bitmap[] mirroredSprites;
        int spriteIndex = 0;
        public float X { get; set; }
        public float Y { get; set; }
        int speed = 3;
        public bool IsAlive { get; set; } = true;
        public bool IsFalling { get; set; } = false;
        public bool IsExploding { get; set; } = false;
        public bool IsCollisionExploding { get; set; } = false;
        public int FallingSpeed { get; set; } = 5;  // Более быстрая скорость падения
        public int ExplosionFrame { get; set; } = 0;
        private Bitmap[] smokeSprites; private Bitmap[] explosionSprites; /* Для взрыва при падении*/ private Bitmap[] airExplosionSprites; /* Для взрыва в воздухе*/
        private Random random = new Random();
        private int collisionYThreshold;
        public bool IsFacingRight { get; set; } = false;
        // Конструктор
        public Enemy(Bitmap[] sprites, Bitmap[] mirroredSprites, float x, float y, Bitmap[] airExplosionSprites, Bitmap[] groundExplosionSprites, Bitmap[] smokeSprites)
        {
            this.sprites = sprites;
            this.mirroredSprites = mirroredSprites;
            X = x;
            Y = y;
            this.airExplosionSprites = airExplosionSprites;
            this.explosionSprites = groundExplosionSprites;
            this.smokeSprites = smokeSprites;
            collisionYThreshold = random.Next(400, 480);
            IsFacingRight = random.Next(2) == 0;
        }
        public int GetWidth() => sprites[0].Width;
        public void Draw(Graphics g)
        {
            if (!IsAlive && !IsFalling && !IsExploding && !IsCollisionExploding) return;
            if (IsExploding) // Взрыв в воздухе
            {
                if (airExplosionSprites != null && ExplosionFrame < airExplosionSprites.Length)
                {
                    g.DrawImage(airExplosionSprites[ExplosionFrame], X, Y);
                    ExplosionFrame++;
                    if (ExplosionFrame >= airExplosionSprites.Length)
                    {
                        Debug.WriteLine("Взрыв закончен. IsAlive = false");
                        IsAlive = false; // Теперь удаляем врага после взрыва в воздухе
                        IsExploding = false;
                        ExplosionFrame = 0;
                    }
                }
                return;
            }
            if (IsFalling) // Падение и дым
            {
                if (smokeSprites != null && ExplosionFrame < smokeSprites.Length)
                {
                    g.DrawImage(smokeSprites[ExplosionFrame], X, Y);
                    Y += FallingSpeed;
                    ExplosionFrame++;
                }
                else
                {
                    StartCollisionExplosion();
                }
                return;
            }
            if (IsCollisionExploding)  // Взрыв при столкновении с землей
            {
                if (explosionSprites != null && ExplosionFrame < explosionSprites.Length)
                {
                    g.DrawImage(explosionSprites[ExplosionFrame], X, Y);
                    ExplosionFrame++;

                    if (ExplosionFrame >= explosionSprites.Length)
                    {
                        IsCollisionExploding = false;
                        IsAlive = false;
                        ExplosionFrame = 0;
                    }
                }
                return;
            }
            g.DrawImage(IsFacingRight ? sprites[spriteIndex] : mirroredSprites[spriteIndex], X, Y);
        }
        public void Update()
        {
            if (!IsFalling && !IsExploding && !IsCollisionExploding && IsAlive)
            {
                // Ограничиваем движение по горизонтали
                if (IsFacingRight)
                {
                    X -= speed;
                    if (X < 0)
                    {
                        IsFacingRight = false;  // Меняем направление, если уперлись в левую границу
                        X = 0;  // Останавливаем
                    }
                }
                else
                {
                    X += speed;
                    if (X + GetWidth() > 800) // Width - ширина формы
                    {
                        IsFacingRight = true;  // Меняем направление, если уперлись в правую границу
                        X = 800 - GetWidth(); // Останавливаем
                    }
                }
                spriteIndex = (spriteIndex == 0) ? 1 : 0;
            }
        }
        public void StartFalling() // Метод для начала падения
        {
            Debug.WriteLine("Начинаем падение");
            IsFalling = true;
            ExplosionFrame = 0;
        }
        public void ExplodeInAir() // Метод для начала взрыва в воздухе
        {
            Debug.WriteLine("Начинаем взрыв в воздухе");
            IsExploding = true;
            IsFalling = false;
            IsCollisionExploding = false;
            ExplosionFrame = 0;
            explosionSprites = airExplosionSprites; // Используем другой набор спрайтов
        }
        public void StartCollisionExplosion() // Метод для начала взрыва при столкновении
        {
            Debug.WriteLine("Начинаем взрыв при столкновении");
            IsFalling = false;
            IsCollisionExploding = true;
            ExplosionFrame = 0;
        }
        public Rectangle GetBounds() => new Rectangle((int)X, (int)Y, sprites[0].Width, sprites[0].Height);
    }
}