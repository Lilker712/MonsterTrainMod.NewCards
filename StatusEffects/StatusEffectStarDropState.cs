using ShinyShoe;
using System;
using System.Collections;
using Trainworks.ConstantsV2;
using static CombatManager;

namespace NewCards.StatusEffects
{
    public class StatusEffectStarDropState : StatusEffectState, IDamageStatusEffect
    {
        public const string StatusId = NewCards.GUID + "StarDrop";
        private CharacterState associatedCharacter;
        private CombatManager combatManager;
        private int stacks;

        public override bool TestTrigger(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            if (inputTriggerParams.damageSourceCard != null && inputTriggerParams.damageSourceCard.GetCardType() == CardType.Spell)
            {
                return TestAttackTrigger(inputTriggerParams, outputTriggerParams);
            }
            else
            {
                return true;
            }
        }

        private bool TestAttackTrigger(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            CharacterState characterState = null;
            if (inputTriggerParams.attacked != null && inputTriggerParams.attacked.IsAlive)
            {
                characterState = inputTriggerParams.attacked;
            }
            if (characterState == null)
            {
                return false;
            }
            if (inputTriggerParams.attacker == null)
            {
                return false;
            }
            if (characterState.HasStatusEffect(VanillaStatusEffectIDs.Phased))
            {
                return false;
            }
            if (characterState.GetStatusEffectStacks(VanillaStatusEffectIDs.Spellshield) > 0)
            {
                return true;
            }
            int statusEffectStacks = characterState.GetStatusEffectStacks(StatusId);
            int damageAdded = GetEffectMagnitude(statusEffectStacks);
            outputTriggerParams.damage = inputTriggerParams.damage + damageAdded;
            outputTriggerParams.count = statusEffectStacks;

            return outputTriggerParams.damage != inputTriggerParams.damage;
        }

        public override int GetEffectMagnitude(int stacks = 1)
        {
            return GetParamInt() * stacks;
        }
    }
}
