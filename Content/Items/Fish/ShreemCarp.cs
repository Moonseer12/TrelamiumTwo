﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using TrelamiumTwo.Core;

namespace TrelamiumTwo.Content.Items.Fish
{
	public class ShreemCarp : ModItem
	{
		public override string Texture => Assets.Items.Fish + "ShreemCarp";
		public override void SetDefaults()
		{
			item.width = item.height = 22;
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 2, copper: 50);
			item.rare = ItemRarityID.Blue;
		}
	}
}
