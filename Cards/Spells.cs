using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using static CharacterTriggerData;
using static Trainworks.Constants.VanillaCardPoolIDs;
using NewCards.StatusEffects;

namespace NewCards.Cards
{
    class Spells
    {
        public static void MakeStygian()
        {
            var Efect0 = new CardEffectDataBuilder
            {//Pyro otrzymuje 3 obrażenia
                EffectStateType = typeof(CardEffectDamage),
                TargetMode = TargetMode.Pyre,
                TargetTeamType = Team.Type.Monsters,
                ParamInt = 3,
            };

            var Efect1 = new CardEffectDataBuilder
            {//nakłada 1 FrostBite
                EffectStateType = typeof(CardEffectAddStatusEffect),
                TargetMode = TargetMode.Room,
                TargetTeamType = Team.Type.Heroes,
                ParamStatusEffects =
                {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Frostbite,
                        count = 1
                    }
                }
            };

            var Efect2 = new CardEffectDataBuilder
            {//zamraża losową kartę w ręce
                EffectStateType = typeof(CardEffectFreezeRandomCard),
                TargetMode = TargetMode.Hand,
            };

            new CardDataBuilder
            {
                Cost = 1,
                CardType = CardType.Spell,
                Rarity = CollectableRarity.Uncommon,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                ClanID = VanillaClanIDs.Stygian,

                CardID = NewCards.GUID + "IceCrystal",
                Name = "Ice Crystal",
                AssetPath = "assets/IceCrystal.png",

                TargetsRoom = true,
                Targetless = true,
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = NewCards.GUID + "Triger" + "IceCrystal",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Your Pyre takes [effect0.power] damage, apply [frostbite] [effect1.status0.power] to enemy units and apply [freeze] to a random card",
                        CardEffectBuilders = { Efect0, Efect1, Efect2 },
                    },
                },

                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitPermafrost)
                    }
                },
            }.BuildAndRegister();

            var Efect3 = new CardEffectDataBuilder
            {//Create random spell

            };

            new CardDataBuilder
            {
                Cost = 1,
                CardType = CardType.Spell,
                Rarity = CollectableRarity.Uncommon,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                ClanID = VanillaClanIDs.Stygian,

                CardID = NewCards.GUID + "TransferredKnowledge",
                Name = "Transferred Knowledge",
                AssetPath = "assets/TransferredKnowledge.png",

                TargetsRoom = true,
                Targetless = true,

                EffectBuilders =
                {
                    Efect1,
                },

                TraitBuilders =
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitExhaustState),
                    },
                },
            }.BuildAndRegister();

        }

        public static void MakeAwoken()
        {
            var Efect0 = new CardEffectDataBuilder
            {//Get 10 Gold.
                EffectStateType = typeof(CardEffectRewardGold),
                TargetTeamType = Team.Type.None,
                ParamInt = 10,
            };

            var Efect1 = new CardEffectDataBuilder
            {//Deal 10 to the front enemy unit.
                EffectStateType = typeof(CardEffectDamage),
                TargetMode = TargetMode.FrontInRoom,
                TargetTeamType = Team.Type.Heroes,
                ParamInt = 10,
            };

            var Efect2 = new CardEffectDataBuilder
            {//Draw +1 next turn.
                EffectStateType = typeof(CardEffectDrawAdditionalNextTurn),
                TargetMode = TargetMode.LastTargetedCharacters,
                ParamInt = 1,
            };

            new CardDataBuilder
            {
                Cost = 0,
                CardType = CardType.Spell,
                Rarity = CollectableRarity.Rare,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                ClanID = VanillaClanIDs.Awoken,

                CardID = NewCards.GUID + "GoldenSting",
                Name = "Golden Sting",
                AssetPath = "assets/TestCard.png",

                TargetsRoom = true,
                Targetless = true,
                Description = "Get [effect0.power] [coin]. Deal [effect1.power] damage to the front enemy unit. Draw +1 next turn.",

                EffectBuilders =
                {
                    Efect0,
                    Efect1,
                    Efect2
                },

            }.BuildAndRegister();

            var Efect3 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectAddStatusEffect),
                TargetMode = TargetMode.FrontInRoom,
                TargetTeamType = Team.Type.Heroes,
                ParamStatusEffects =
                {
                    new StatusEffectStackData
                    {
                        statusId = StatusEffectPoison2State.StatusId,
                        count = 4
                    }
                }
            };

            new CardDataBuilder
            {
                Cost = 0,
                CardType = CardType.Spell,
                Rarity = CollectableRarity.Rare,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                ClanID = VanillaClanIDs.Awoken,

                CardID = NewCards.GUID + "PoisonSting",
                Name = "Poison Sting",
                AssetPath = "assets/TestCard.png",

                TargetsRoom = true,
                Targetless = true,
                Description = "Apply <nobr><b>Poison</b> [effect0.status0.power]</nobr> to the front enemy unit.",

                EffectBuilders =
                {
                    Efect3
                }
            }.BuildAndRegister();
        }
    }
}
