﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

using TrelamiumTwo.Common.Items;

namespace TrelamiumTwo.Content.Items.Consumables.Food
{
	public sealed class Ginger : FoodItem
	{
		public override void SetStaticDefaults()
		=> DisplayName.SetDefault("Ginger");
		public override void SetDefaults()
		{
			item.maxStack = 30;
			item.rare = ItemRarityID.White;
			item.value = Item.buyPrice(silver: 2);

			item.useTime = item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.EatingUsing;

			item.useTurn = true;
			item.consumable = true;
			ExpireTimer = 12000;

			item.buffType = BuffID.WellFed;
			item.buffTime = 6000;
			item.UseSound = SoundID.Item3;
		}
        public override void OnConsumeItem(Player player)
        {
			var Index = CombatText.NewText(player.Hitbox, Color.IndianRed, "Well Fed [IV]", true, false);
			Main.combatText[Index].lifeTime = 120;
		}
    }
}
