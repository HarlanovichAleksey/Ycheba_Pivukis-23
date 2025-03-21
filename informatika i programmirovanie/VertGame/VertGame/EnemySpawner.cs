using System;
using System.Collections.Generic;
using System.Drawing;
namespace VertGame
{
    class EnemySpawner
    {
        private Bitmap[] vert1Right; private Bitmap[] vert1Left; private Bitmap[] vert3Right; private Bitmap[] vert3Left;
        private Bitmap[] airExplosionSprites; private Bitmap[] explosionSprites; private Bitmap[] smokeSprites;
        public EnemySpawner(Bitmap[] vert1Right, Bitmap[] vert1Left, Bitmap[] vert3Right, Bitmap[] vert3Left, Bitmap[] airExplosionSprites, Bitmap[] explosionSprites, Bitmap[] smokeSprites)
        {
            this.vert1Right = vert1Right; this.vert1Left = vert1Left;
            this.vert3Right = vert3Right; this.vert3Left = vert3Left;
            this.airExplosionSprites = airExplosionSprites;
            this.explosionSprites = explosionSprites;
            this.smokeSprites = smokeSprites;
        }
        public List<Enemy> SpawnEnemies(int count, int width)
        {
            List<Enemy> enemies = new List<Enemy>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                Bitmap[] selectedSpritesRight; Bitmap[] selectedSpritesLeft;
                if (random.Next(2) == 0) // Случайный выбор вертолёта (1 или 3)
                {
                    selectedSpritesRight = vert1Right;
                    selectedSpritesLeft = vert1Left;
                }
                else
                {
                    selectedSpritesRight = vert3Right;
                    selectedSpritesLeft = vert3Left;
                }
                // Случайный выбор стороны появления (лево или право)
                int startX = random.Next(0, width - 50);  // Ширина врага (приблизительно)
                int startY = random.Next(50, 150); // Случайная Y-координата, но не выше 50
                // Передаем все наборы спрайтов для взрывов
                Enemy enemy = new Enemy(selectedSpritesRight, selectedSpritesLeft, startX, startY, airExplosionSprites, explosionSprites, smokeSprites);
                enemy.IsFacingRight = random.Next(2) == 0; // случайное направление
                enemies.Add(enemy);
            }
            return enemies;
        }
    }
}