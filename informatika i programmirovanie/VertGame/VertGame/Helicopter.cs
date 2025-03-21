using System;
using System.Drawing;
namespace VertGame
{
    class Helicopter
    {
        public Bitmap[] CurrentSprites { get; set; }
        int spriteIndex = 0;
        public int X { get; set; }
        public int Y { get; set; }
        int speed = 5;
        public int GetWidth() => CurrentSprites[0].Width; //  Вычисляем ширину
        public int GetHeight() => CurrentSprites[0].Height; // Вычисляем высоту
        public int MaxHeight { get; set; }
        public bool IsExploding { get; set; } = false;
        public int ExplosionFrame { get; set; } = 0;
        public int ExplosionType { get; set; } = 0; // 0 - нет, 1 - взрыв в воздухе, 2 - взрыв при падении
        public bool IsDead { get; set; } = false;
        public bool MoveUp { get; set; } = false;
        public bool MoveDown { get; set; } = false;
        public bool MoveLeft { get; set; } = false;
        public bool MoveRight { get; set; } = false;
        public Bitmap[] CurrentRocketSprites { get; set; } //  спрайты ракет
        private Bitmap[] explosionSprites; // Спрайты взрыва
        public Helicopter(Bitmap[] sprites, int x, int y, Bitmap[] explosionSprites) // Добавили explosionSprites в конструктор
        {
            CurrentSprites = sprites;
            X = x;
            Y = y;
            CurrentRocketSprites = Properties.Resources.rocket1__1_ != null ? new Bitmap[] { Properties.Resources.rocket1__1_, Properties.Resources.rocket1__2_, Properties.Resources.rocket1__3_, Properties.Resources.rocket1__4_ } : null;
            this.explosionSprites = explosionSprites; // Инициализация explosionSprites
        }
        public void Draw(Graphics g)
        {
            if (!IsExploding)
            {
                g.DrawImage(CurrentSprites[spriteIndex], X, Y);
            }
            else
            {
                if (explosionSprites != null && ExplosionFrame < explosionSprites.Length) // Если вертолет взрывается, рисуем кадры взрыва
                {
                    g.DrawImage(explosionSprites[ExplosionFrame], X, Y);
                    // g.DrawImage(explosionSprites[Math.Min(ExplosionFrame, explosionSprites.Length - 1)], X, Y);  //безопасная отрисовка
                }
            }
        }
        public void Update()
        {
            if (!IsExploding)
            {
                if (MoveUp) Y -= speed;
                if (MoveDown) Y += speed;
                if (MoveLeft) X -= speed;
                if (MoveRight) X += speed;

                spriteIndex = (spriteIndex == 0) ? 1 : 0;
            }
            else
            {
                // Во время взрыва увеличиваем ExplosionFrame
                ExplosionFrame++;

                // Если взрыв закончился, отмечаем вертолет как мертвый
                if (ExplosionFrame >= explosionSprites.Length)
                {
                    IsDead = true;
                }
            }
        }
        public void SetSprites(Bitmap[] newSprites)
        {
            CurrentSprites = newSprites;
        }
        public Rectangle GetBounds() => new Rectangle(X, Y, GetWidth(), GetHeight());
        public void Explode(Bitmap[] explosionSprites)
        {
            IsExploding = true;
            MoveUp = MoveDown = MoveLeft = MoveRight = false;
            ExplosionFrame = 0;
            this.explosionSprites = explosionSprites;
        }
    }
}