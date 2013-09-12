using Charlotte.Shooter.Players;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public abstract class EnemyProjectile : Projectile
    {
        public BoundingSphere[] CollisionSpheres;
        public BoundingBox[] CollisionBoxes;
    }
}
