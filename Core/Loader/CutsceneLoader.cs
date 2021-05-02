﻿using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.UI;
using TrelamiumTwo.Core.Abstracts;

namespace TrelamiumTwo.Core.Loaders
{
	internal sealed class CutsceneLoader : ILoadable
	{
		public float Priority => 1f;

		public bool LoadOnDedServer => false;

		public static List<Cutscene> Cutscenes = new List<Cutscene>();

		public void Load(Mod mod)
		{
			foreach (Type t in mod.Code.GetTypes())
			{
				if (t.IsSubclassOf(typeof(Cutscene)))
				{
					var cutscene = (Cutscene)Activator.CreateInstance(t, null);

					Cutscenes.Add(cutscene);
				}
			}
		}

		public void Unload() => Cutscenes?.Clear();

		public static void AddCutsceneLayer(List<GameInterfaceLayer> layers, Cutscene cutscene, int index, bool visible)
		{
			string name = cutscene == null ? "Unknown" : cutscene.GetType().Name;

			layers.Insert(index, new LegacyGameInterfaceLayer(TrelamiumTwo.AbbreviationPrefix + name,
				delegate 
				{
					if (visible)
						cutscene?.Draw();

					return true;
				},
				InterfaceScaleType.UI
				));
		}
		
		public static T GetCutscene<T>() where T : Cutscene => Cutscenes.FirstOrDefault(c => c is T) as T;
	}
}
