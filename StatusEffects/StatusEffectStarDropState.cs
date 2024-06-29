using ShinyShoe;
using ShinyShoe.Logging;
using System;
using System.Collections;
using Trainworks.ConstantsV2;
using static CombatManager;

namespace NewCards.StatusEffects
{
    public class StatusEffectStarDropState : StatusEffectState
    {
        public const string StatusId = NewCards.GUID + "StarDrop";

        public override bool TestTrigger(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            if (inputTriggerParams.damageSourceCard != null && inputTriggerParams.damageSourceCard.GetCardType() == CardType.Spell)
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
                if (characterState.HasShieldingStatusEffect())
                {
                    int num = inputTriggerParams.damageSourceCard.HasTrait(typeof(CardTraitIgnoreArmor)) ? 1 : 0;
                    bool flag = characterState.HasStatusEffect("untouchable");
                    if (num == 0 || flag)
                    {
                        return false;
                    }
                }
                int statusEffectStacks = characterState.GetStatusEffectStacks(base.GetStatusId());
                int damageAdder = this.GetEffectMagnitude(statusEffectStacks);
                outputTriggerParams.damage = inputTriggerParams.damage + damageAdder;
                outputTriggerParams.count = statusEffectStacks;
            }
            return outputTriggerParams.damage != inputTriggerParams.damage;
        }

        public override int GetEffectMagnitude(int stacks = 1)
        {
            return GetParamInt() * stacks;
        }
    }
}
