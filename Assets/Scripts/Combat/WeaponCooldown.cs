using System;

namespace ExploratoryGame.Combat
{
    public sealed class WeaponCooldown
    {
        public float CooldownSeconds { get; }
        public float RemainingSeconds { get; private set; }

        public WeaponCooldown(float cooldownSeconds)
        {
            if (cooldownSeconds <= 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(cooldownSeconds), "Cooldown must be greater than zero.");
            }

            CooldownSeconds = cooldownSeconds;
            RemainingSeconds = 0f;
        }

        public bool TryFire()
        {
            if (RemainingSeconds > 0f)
            {
                return false;
            }

            RemainingSeconds = CooldownSeconds;
            return true;
        }

        public void Tick(float deltaTime)
        {
            if (deltaTime < 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(deltaTime), "Delta time cannot be negative.");
            }

            RemainingSeconds -= deltaTime;

            if (RemainingSeconds < 0f)
            {
                RemainingSeconds = 0f;
            }
        }
    }
}
