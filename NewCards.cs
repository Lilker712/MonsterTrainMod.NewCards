using BepInEx;
using HarmonyLib;
using Trainworks;
using System;
using Trainworks.Interfaces;
using Trainworks.Managers;
using static RimLight;
using UnityEngineInternal;
using UnityEngine;
using NewCards.Cards;
using NewCards.StatusEffects;

namespace NewCards
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("tools.modding.trainworks")]
    public class NewCards : BaseUnityPlugin, IInitializable
    {
        public const string GUID = "820940fe.8246.42a2.New.Cards";
        public const string NAME = "New Cards";
        public const string VERSION = "0.1.1";

        private void Awake()
        {
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }

        public void Initialize()//dont forget about this
        {
            //Spells.MakeHellhorned();
            //Monsters.MakeHellhorned();
            Spells.MakeAwoken();
            Monsters.MakeAwoken();
            Spells.MakeStygian();
            Monsters.MakeStygian();
            //Spells.MakeUmbra();
            //Monsters.MakeUmbra();
            //Spells.MakeMeltingRemnant();
            //Monsters.MakeRemnant();

            Poison2.BuildAndRegister();
            StarDrop.BuildAndRegister();

        }

        //adding cards to starting hand
        [HarmonyPatch(typeof(SaveManager), nameof(SaveManager.SetupRun))]
        class AddToStartinDeck
        {
            static void Postfix(ref SaveManager __instance)
            {
                var id = NewCards.GUID + "IceCrystal";
                __instance.AddCardToDeck(CustomCardManager.GetCardDataByID(id));
            }
        }
    }
}
