using System;

namespace ExploratoryGame.Missions
{
    public enum MissionState
    {
        NotStarted,
        Active,
        Success,
        Failed
    }

    public sealed class MissionProgress
    {
        public int RequiredKills { get; }
        public int CurrentKills { get; private set; }
        public MissionState State { get; private set; }
        public bool RewardGranted { get; private set; }

        public MissionProgress(int requiredKills)
        {
            if (requiredKills <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(requiredKills), "Required kills must be greater than zero.");
            }

            RequiredKills = requiredKills;
            State = MissionState.Active;
        }

        public void RegisterKill()
        {
            if (State != MissionState.Active)
            {
                return;
            }

            CurrentKills++;

            if (CurrentKills >= RequiredKills)
            {
                State = MissionState.Success;
            }
        }

        public bool TryGrantReward()
        {
            if (State != MissionState.Success || RewardGranted)
            {
                return false;
            }

            RewardGranted = true;
            return true;
        }
    }
}
