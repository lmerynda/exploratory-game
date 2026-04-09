using System;
using System.Collections.Generic;

namespace ExploratoryGame.Upgrades
{
    public sealed class UpgradeInventory
    {
        private readonly HashSet<string> _owned = new();

        public int Credits { get; private set; }

        public UpgradeInventory(int startingCredits)
        {
            if (startingCredits < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startingCredits), "Starting credits cannot be negative.");
            }

            Credits = startingCredits;
        }

        public bool TryPurchase(string upgradeId, int price)
        {
            if (string.IsNullOrWhiteSpace(upgradeId))
            {
                throw new ArgumentException("Upgrade ID is required.", nameof(upgradeId));
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            }

            if (_owned.Contains(upgradeId))
            {
                return false;
            }

            if (Credits < price)
            {
                return false;
            }

            Credits -= price;
            _owned.Add(upgradeId);
            return true;
        }
    }
}
