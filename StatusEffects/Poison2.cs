using Trainworks.BuildersV2;

namespace NewCards.StatusEffects
{
    class Poison2
    {
        public static void BuildAndRegister()
        {
            new StatusEffectDataBuilder
            {
                StatusEffectStateType = typeof(StatusEffectPoison2State),
                StatusID = StatusEffectPoison2State.StatusId,
                Name = "Poison",
                Description = "Unit takes damage equal to the number of Poison stacks at end of turn",
                DisplayCategory = StatusEffectData.DisplayCategory.Negative,
                TriggerStage = StatusEffectData.TriggerStage.OnPostCombatPoison,
                RemoveAtEndOfTurn = false,
                RemoveStackAtEndOfTurn = false,
                IconPath = "assets/PoisonStatus.png",
                ParamInt = 1,
            }.Build();
        }
    }
}