using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PortableBunnyCannon.Content.Items.Weapons
{
	public class PBC : ModItem
	{
		public override void SetDefaults() 
		{
			// Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

			// Common Properties
			Item.width = 88; // Hitbox width of the item.
			Item.height = 33; // Hitbox height of the item.
			Item.scale = 1.0f;
			Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
			Item.value = Item.buyPrice(gold: 50);

			// Use Properties
			Item.useTime = 32; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 30; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = false; // Whether or not you can hold click to automatically use it again.

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 111; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.

			// Gun Properties
			Item.shoot = ProjectileID.ExplosiveBunny; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 12f; // The speed of the projectile (measured in pixels per frame.) This value equivalent to Handgun
			Item.useAmmo = ItemID.ExplosiveBunny; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient( ItemID.BunnyCannon)
				.AddIngredient( ItemID.GrenadeLauncher)
				.AddIngredient( ItemID.HallowedBar, 25)
				.AddIngredient( ItemID.IllegalGunParts, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
		
		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset() {
			return new Vector2(-20f, -10f);
		}
		
		// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
		// Uzi/Molten Fury style: Replace normal Bullets with High Velocity
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 30f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
		}
	}
}
