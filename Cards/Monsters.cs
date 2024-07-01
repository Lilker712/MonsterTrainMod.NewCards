using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using NewCards.StatusEffects;
using static CharacterTriggerData;
using System.Linq;
using Trainworks.Managers;

namespace NewCards.Cards
{
    class Monsters
    {
        public static void MakeStygian(){
            
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

            var TrigEffect0 = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectAddBattleCard),
                //TargetMode = TargetMode.Room,
                //TargetTeamType = Team.Type.None,
                ParamInt = (int)CardPile.HandPile,
                ParamCardPool = CustomCardPoolManager.GetMegaPool(),
                ParamCardUpgradeDataBuilder = UpgradeEffect,
                FilterBasedOnMainSubClass = true,
                ParamCardFilter = new CardUpgradeMaskDataBuilder
                {
                    CardUpgradeMaskID = "OnlySpells",
                    CardType = CardType.Spell,
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
                AssetPath = "assets/TestCard.png",

                TargetsRoom = true,
                Targetless = false,

                EffectBuilders =
                {
                    CreateUnit0,
                }
            }.BuildAndRegister();
            

            var TrigEffect1 = new CardEffectDataBuilder
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

            var Trigger1 = new CharacterTriggerDataBuilder
            {
                TriggerID = NewCards.GUID + "Trigger1",
                Trigger = CharacterTriggerData.Trigger.CardSpellPlayed,
                Description = "Apply <nobr><b>Star Drop[effect0.status0.power]</b></nobr>to random enemy unit Three times",
                EffectBuilders =
                {
                    TrigEffect1,
                    TrigEffect1,
                    TrigEffect1,
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

                CardID = NewCards.GUID + "StarfallSorcerer",
                Name = "Starfall Sorcerer ",
                AssetPath = "assets/TestCard.png",

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