using Charlotte.Shooter.Players;
using Charlotte.Shooter.Projectiles.EnemyProjectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Shooter.Projectiles
{
    public abstract class Projectile : Sprite.Sprite
    {
        /// <summary>
        /// The HP of the enemy.
        /// </summary>
        public float HP { get; set; }

        /// <summary>
        /// The Max HP of the enemy.
        /// </summary>
        public float MaxHP { get; set; }

        /// <summary>
        /// The power of the projectile when hits with the player.
        /// </summary>
        public float Power { get; set; }

        /// <summary>
        /// The level that is associated with the enemy.
        /// </summary>
        public Level AssociatedLevel { get; set; }


        /// <summary>
        /// Indicate whether the enemy should be deleted regardless of its HP or not.
        /// </summary>
        public abstract bool ToBeDeleted();

        /// <summary>
        /// The update logic of the enemy.
        /// </summary>
        public abstract void Update(GameTime gt);

        /// <summary>
        /// Shoot another projectile into the game.
        /// </summary>
        /// <param name="p">The other projectile to be put onto the screen.</param>
        public void Shoot(EnemyProjectile p)
        {
            AssociatedLevel.Waves[AssociatedLevel.CurrentWaveNo].Add(p);
        }
    }
}
