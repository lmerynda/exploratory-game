using System;

namespace ExploratoryGame.Combat
{
    public sealed class DamageModel
    {
        public int Shield { get; private set; }
        public int Hull { get; private set; }

        public DamageModel(int shield, int hull)
        {
            if (shield < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(shield), "Shield cannot be negative.");
            }

            if (hull <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(hull), "Hull must be greater than zero.");
            }

            Shield = shield;
            Hull = hull;
        }

        public void ApplyDamage(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Damage amount cannot be negative.");
            }

            var pending = amount;

            if (Shield > 0)
            {
                var absorbed = pending <= Shield ? pending : Shield;
                Shield -= absorbed;
                pending -= absorbed;
            }

            if (pending > 0)
            {
                Hull -= pending;

                if (Hull < 0)
                {
                    Hull = 0;
                }
            }
        }
    }
}
