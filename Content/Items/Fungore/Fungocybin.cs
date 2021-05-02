using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TrelamiumTwo.Content.Items.Fungore
{
	public class Fungocybin : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fungocybin");
			Tooltip.SetDefault("Summons a fungus symbiote");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 100;
			item.rare = ItemRarityID.Yellow;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(NPCType<NPCs.Fungore.Fungore>());
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Fungore.Fungore>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 8);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}