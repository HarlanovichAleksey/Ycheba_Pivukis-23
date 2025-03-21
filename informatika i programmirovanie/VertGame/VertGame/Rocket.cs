using System.Drawing;
namespace VertGame
{
    class Rocket
    {
        Bitmap[] sprites;
        int spriteIndex = 0;
        public float X { get; set; }
        public float Y { get; set; }
        int speed = 10;
        public bool IsActive = true;
        public bool IsFacingRight { get; set; } // Направление ракеты
        public int GetWidth() => sprites[0].Width;
        public Rocket(Bitmap[] sprites, float x, float y)
        {
            this.sprites = sprites;
            X = x;
            Y = y;
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(sprites[spriteIndex], X, Y);
        }
        public void Update()
        {
            if (IsFacingRight)  // Двигаемся в зависимости от направления
            {
                X += speed;
            }
            else
            {
                X -= speed;
            }
            spriteIndex = (spriteIndex + 1) % sprites.Length;
        }
        public Rectangle GetBounds() => new Rectangle((int)X, (int)Y, sprites[0].Width, sprites[0].Height);
    }
}