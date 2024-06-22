using Trainworks.BuildersV2;

namespace NewCards.StatusEffects
{
    class StarDrop
    {
        public static void BuildAndRegister()
        {
            new StatusEffectDataBuilder
            {
                StatusEffectStateType = typeof(StatusEffectStarDropState),
                StatusID = StatusEffectStarDropState.StatusId,
                Name = "Star Drop",
                Description = "Unit takes additional damage equal to the number of Star Drop stacks when attacked by spell",
                DisplayCategory = StatusEffectData.DisplayCategory.Negative,
                TriggerStage = StatusEffectData.TriggerStage.OnPreAttacked,
                RemoveAtEndOfTurn = true,// test if remove one?
                IconPath = "assets/status_StarDrop.png",
                ParamInt = 1,
            }.Build();
        }
    }
}