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
            var TrigEffect0 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectAddStatusEffect),
                TargetMode = TargetMode.Self,
                TargetTeamType = Team.Type.Monsters,
                ParamStatusEffects =
                    {
                        new StatusEffectStackData
                        {
                            statusId = StatusEffectPoison2State.StatusId,
                            count = 3,
                        }
                    }
            };

            var Trigger0 = new CharacterTriggerDataBuilder
            {
                TriggerID = NewCards.GUID + "TriggerPoisonousSapwoodUnit",
                Trigger = CharacterTriggerData.Trigger.OnHit,
                Description = "apply <nobr><b>Poison [effect0.status0.power]</b></nobr>",
                EffectBuilders =
                {
                    TrigEffect0,
                }
            };

            var Efect0 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectSpawnMonster),
                TargetMode = TargetMode.DropTargetCharacter,
                ParamCharacterDataBuilder = new CharacterDataBuilder
                {
                    CharacterID = NewCards.GUID + "PoisonousSapwoodUnit",
                    Name = "Poisonous Sapwood",
                    Size = 3,
                    Health = 45,
                    AttackDamage = 0,
                    AssetPath = "assets/Unit.png",
                    TriggerBuilders =
                    {
                        Trigger0,
                    }
                }
            };

            new CardDataBuilder
            {
                Cost = 2,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool, VanillaCardPoolIDs.AwokenBanner },
                ClanID = VanillaClanIDs.Awoken,

                CardID = NewCards.GUID + "Poisonous Sapwood",
                Name = "Poisonous Sapwood",
                Description = "<b>Revenge:</b> apply <nobr><b>Poison [effect0.status0.power]</b></nobr>",
                AssetPath = "assets/CardUnit.png",

                TargetsRoom = true,
                Targetless = false,

                EffectBuilders =
                {
                    Efect0,
                }
            }.BuildAndRegister();

        }
    }
}