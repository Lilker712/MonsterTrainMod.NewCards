﻿using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using NewCards.StatusEffects;
using static CharacterTriggerData;
using System.Linq;

namespace NewCards.Cards
{
    class Monsters
    {
        public static void MakeStygian(){

            /*
            var UpgradeEffect = new CardUpgradeDataBuilder {
                UpgradeID = NewCards.GUID + "AddConsume",
                TraitDataUpgradeBuilders =
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitExhaustState),
                    }
                },
            };

            CardPool cardPool0 = new CardPoolBuilder
            {
                CardPoolID = "all",
                CardIDs = new List<string>
                    {
                        VanillaCardPoolIDs.MegaPool,
                        //VanillaCardPoolIDs.StingOnlyPool,
                    },
            }.Build();

            var TrigEffect0 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectAddBattleCard),
                TargetMode = TargetMode.Room,
                TargetTeamType = Team.Type.None,
                ParamInt = 3,
                ParamCardPool = cardPool0,
                ParamCardUpgradeDataBuilder = UpgradeEffect,
                ParamCardFilter = new CardUpgradeMaskDataBuilder
                {
                    CardUpgradeMaskID = "MinusMonster",
                    CardType = CardType.Monster,
                }.Build(),
            };

            var Trigger0 = new CharacterTriggerDataBuilder
            {
                TriggerID = NewCards.GUID + "TriggerSpellweaverSirenUnit",
                Trigger = Trigger.PostCombat,
                Description = "Create Random Spell card at end of the turn",
                EffectBuilders =
                {
                    TrigEffect0,
                }
            };

            var CreateUnit0 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectSpawnMonster),
                TargetMode = TargetMode.DropTargetCharacter,
                ParamCharacterDataBuilder = new CharacterDataBuilder
                {
                    CharacterID = NewCards.GUID + "SpellweaverSirenUnit",
                    Name = "Spellweaver Siren",
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
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool, VanillaCardPoolIDs.StygianBanner },
                ClanID = VanillaClanIDs.Stygian,

                CardID = NewCards.GUID + "SpellweaverSiren",
                Name = "Spellweaver Siren",
                AssetPath = "assets/CardUnit.png",

                TargetsRoom = true,
                Targetless = false,

                EffectBuilders =
                {
                    CreateUnit0,
                }
            }.BuildAndRegister();
            */

            var TrigEffect1a = new CardEffectDataBuilder
            {//apply to enemys 2 Stardrops
                EffectStateType = typeof(CardEffectAddStatusEffect),
                TargetMode = TargetMode.RandomInRoom,
                TargetTeamType = Team.Type.Heroes,
                ParamStatusEffects =
                {
                    new StatusEffectStackData
                    {
                        statusId = StatusEffectStarDropState.StatusId,
                        count = 2,
                    }
                }
            };

            var TrigEffect1b = new CardEffectDataBuilder
            {//apply 1 damage to enemy
                EffectStateType = typeof(CardEffectDamage),
                TargetMode = TargetMode.LastDamagedCharacters,
                TargetTeamType = Team.Type.Heroes,
                ParamInt = 1,
            };

            var Trigger1 = new CharacterTriggerDataBuilder
            {
                TriggerID = NewCards.GUID + "Trigger",
                Trigger = CharacterTriggerData.Trigger.CardSpellPlayed,
                Description = "Apply <nobr><b>Star Drop[effect0.status0.power]</b></nobr> and deal 1 damage to random enemy unit Two times",
                EffectBuilders =
                {
                    TrigEffect1a,
                    TrigEffect1b,
                    TrigEffect1a,
                    TrigEffect1b,
                }
            };

            var CreateUnit1 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectSpawnMonster),
                TargetMode = TargetMode.DropTargetCharacter,
                ParamCharacterDataBuilder = new CharacterDataBuilder
                {
                    CharacterID = NewCards.GUID + "StarfallSorcererUnit",
                    Name = "Starfall Sorcerer",
                    Size = 1,
                    Health = 1,
                    AttackDamage = 0,
                    AssetPath = "assets/Unit.png",
                    TriggerBuilders =
                    {
                        Trigger1,
                    }
                }
            };

            new CardDataBuilder
            {
                Cost = 2,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool, VanillaCardPoolIDs.StygianBanner },
                ClanID = VanillaClanIDs.Stygian,

                CardID = NewCards.GUID + "StarfallSorcerer ",
                Name = "Starfall Sorcerer ",
                AssetPath = "assets/CardUnit.png",

                TargetsRoom = true,
                Targetless = false,

                EffectBuilders =
                {
                    CreateUnit1,
                }
            }.BuildAndRegister();
        }
        public static void MakeAwoken()
        {
            var TrigEffect0 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectAddStatusEffect),
                TargetMode = TargetMode.LastAttackerCharacter,
                TargetTeamType = Team.Type.Heroes,
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
                Description = "Apply <nobr><b>Poison [effect0.status0.power]</b></nobr> to enemy units.",
                EffectBuilders =
                {
                    TrigEffect0,
                }
            };

            var CreateUnit0 = new CardEffectDataBuilder
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

                CardID = NewCards.GUID + "PoisonousSapwood",
                Name = "Poisonous Sapwood",
                AssetPath = "assets/CardUnit.png",

                TargetsRoom = true,
                Targetless = false,

                EffectBuilders =
                {
                    CreateUnit0,
                }
            }.BuildAndRegister();

        }
    }
}