using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace PortableBunnyCannon
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class PortableBunnyCannon : Mod
	{

	}
	
	public class AmmoModificationsGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item entity)
		{
			if (entity.type == ItemID.ExplosiveBunny)
			{
				entity.ammo = ItemID.ExplosiveBunny;
			}
		}

		public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
		{
			if (ammo.type == ItemID.ExplosiveBunny)
			{
				type = ProjectileID.ExplosiveBunny;//ModContent.ProjectileType<RopeShot>();
			}
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			// Add ammo tooltip since it doesn't have it because the Placeable ("Can be placed") tooltip replaces it
			// Only needs to be done for placeable items (walls/blocks)
			if (item.type == ItemID.ExplosiveBunny)// || item.type == ItemID.VineRope)
			{
				int index = tooltips.FindLastIndex(tt => tt.Mod.Equals("Terraria") && tt.Name.Equals("Consumable"));
				if (index != -1)
				{
					tooltips.Insert(index + 1, new TooltipLine(Mod, "Ammo", Language.GetTextValue("LegacyTooltip.34")));
				}
			}
		}
	}
}
