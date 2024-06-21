using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using NewCards.StatusEffects;

namespace NewCards.Cards
{
    class Monsters
    {
        public static void MakeStygian()
        {
            CardDataBuilder card = new CardDataBuilder
            {
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                ClanID = VanillaClanIDs.Stygian,

                CardID = NewCards.GUID + "SumonUnitTest",
                Name = "SumonUnitTest",
                Description = "Sumons UnitTest",
                AssetPath = "assets/CardUnit.png",

                TargetsRoom = true,
                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectSpawnMonster),
                        TargetMode = TargetMode.DropTargetCharacter,
                        ParamCharacterDataBuilder = new CharacterDataBuilder
                        {
                            CharacterID = NewCards.GUID + "UnitTest",
                            Name = "UnitTest",
                            Size = 2,
                            Health = 10,
                            AttackDamage = 30,
                            AssetPath = "assets/Unit.png",
                        }
                    }
                }

            };
            card.BuildAndRegister();
        }

        public static void MakeAwoken()
        {
            CardDataBuilder card = new CardDataBuilder
            {
                Cost = 2,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                ClanID = VanillaClanIDs.Awoken,

                CardID = NewCards.GUID + "SumonUnitTest",
                Name = "",
                Description = "",
                AssetPath = "assets/CardUnit.png",

                TargetsRoom = true,
                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectSpawnMonster),
                        TargetMode = TargetMode.DropTargetCharacter,
                        ParamCharacterDataBuilder = new CharacterDataBuilder
                        {
                            CharacterID = NewCards.GUID + "UnitTest",
                            Name = "UnitTest",
                            Size = 2,
                            Health = 10,
                            AttackDamage = 30,
                            AssetPath = "assets/Unit.png",
                        }
                    }
                }

            };
            card.BuildAndRegister();
        }
    }
}
