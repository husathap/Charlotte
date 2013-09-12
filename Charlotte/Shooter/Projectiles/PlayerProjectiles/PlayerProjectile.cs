using Charlotte.Shooter.Players;
using Charlotte.Shooter.Projectiles.EnemyProjectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.PlayerProjectiles
{
    public abstract class PlayerProjectile : Projectile
    {
        /// <summary>
        /// Check whether if the projectile has collided with the player or not.
        /// </summary>
        /// <returns>True if there is a collision.</returns>
        public abstract bool CollidedWithEnemy(EnemyProjectile p);
    }
}
