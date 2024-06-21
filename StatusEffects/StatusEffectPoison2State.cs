using ShinyShoe;
using System;
using System.Collections;
using Trainworks.ConstantsV2;
using static CombatManager;

namespace NewCards.StatusEffects
{
    public class StatusEffectPoison2State : StatusEffectState, IDamageStatusEffect
    {
        public const string StatusId = NewCards.GUID + "Poison";
        private CharacterState associatedCharacter;
        private CombatManager combatManager;
        private int stacks;
        public override bool TestTrigger(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            if (inputTriggerParams.associatedCharacter != null && inputTriggerParams.associatedCharacter.IsAlive)
            {
                this.associatedCharacter = inputTriggerParams.associatedCharacter;
            }
            else
            {
                this.associatedCharacter = null;
            }
            this.combatManager = inputTriggerParams.combatManager;
            CharacterState characterState = this.associatedCharacter;
            this.stacks = ((characterState != null) ? characterState.GetStatusEffectStacks(base.GetStatusId()) : 0);

            return this.stacks > 0 && this.combatManager != null && this.associatedCharacter != null;
        }

        protected override IEnumerator OnTriggered(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            CoreSignals.DamageAppliedPlaySound.Dispatch(Damage.Type.Poison);
            CombatManager combatManager = this.combatManager;
            int damageAmount = this.GetDamageAmount(this.stacks);
            CharacterState target = this.associatedCharacter;
            CombatManager.ApplyDamageToTargetParameters parameters = default(CombatManager.ApplyDamageToTargetParameters);
            parameters.damageType = Damage.Type.Poison;
            StatusEffectData sourceStatusEffectData = base.GetSourceStatusEffectData();
            parameters.vfxAtLoc = ((sourceStatusEffectData != null) ? sourceStatusEffectData.GetOnAffectedVFX() : null);
            parameters.showDamageVfx = true;

            yield return combatManager.ApplyDamageToTarget(damageAmount, target, parameters);

            

            yield break;
        }

        private int GetDamageAmount(int stacks)
        {
            return GetParamInt() * stacks;
        }

    }
}