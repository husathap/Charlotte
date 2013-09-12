using Charlotte.Shooter.Projectiles;
using Charlotte.Shooter.Projectiles.PlayerProjectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Players
{
    public abstract class Player : Sprite.Sprite
    {
        /// <summary>
        /// The level that the player is in.
        /// </summary>
        public Level AssociatedLevel;

        /// <summary>
        /// The HP of the player.
        /// </summary>
        public float HP { get; set; }

        /// <summary>
        /// The maximum HP of the player.
        /// </summary>
        public float MaxHP { get; set; }

        /// <summary>
        /// The PP of the player.
        /// </summary>
        public float PP { get; set; }

        /// <summary>
        /// The maximum PP of the player.
        /// </summary>
        public float MaxPP { get; set; }

        protected BoundingSphere collisionSphere = new BoundingSphere(new Vector3(0, 0, 0), 0);
        /// <summary>
        /// The collision sphere of the player.
        /// </summary>
        public BoundingSphere CollisionSphere
        {
            get { return collisionSphere; }
        }

        /// <summary>
        /// Shoot the player's projectile onto the screen.
        /// </summary>
        /// <param name="p">The projectile.</param>
        public void Shoot(PlayerProjectile p)
        {
            AssociatedLevel.PlayerProjectiles.Add(p);
        }

        public void PlayerUpdate(KeyboardState ks)
        {
            collisionSphere.Center.X = this.X;
            collisionSphere.Center.Y = this.Y;
            PlayerInputUpdate(ks);
        }

        /// <summary>
        /// Updating the player's input.
        /// </summary>
        /// <param name="ks"></param>
        protected abstract void PlayerInputUpdate(KeyboardState ks);
    }
}
