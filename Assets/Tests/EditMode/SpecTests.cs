using System;
using ExploratoryGame.Combat;
using ExploratoryGame.Missions;
using ExploratoryGame.Upgrades;
using NUnit.Framework;

namespace ExploratoryGame.Tests.EditMode
{
    public class SpecTests
    {
        [Test]
        public void Mission_RemainsActive_WhenKillsBelowRequirement()
        {
            var mission = new MissionProgress(requiredKills: 5);

            for (var i = 0; i < 4; i++)
            {
                mission.RegisterKill();
            }

            Assert.That(mission.State, Is.EqualTo(MissionState.Active));
        }

        [Test]
        public void Mission_Succeeds_AndRewardGrantedOnlyOnce()
        {
            var mission = new MissionProgress(requiredKills: 2);

            mission.RegisterKill();
            mission.RegisterKill();

            Assert.That(mission.State, Is.EqualTo(MissionState.Success));
            Assert.That(mission.TryGrantReward(), Is.True);
            Assert.That(mission.TryGrantReward(), Is.False);
        }

        [Test]
        public void Mission_RequiresPositiveKillCount()
        {
            Assert.That(() => new MissionProgress(requiredKills: 0), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WeaponCooldown_BlocksFire_UntilElapsed()
        {
            var cooldown = new WeaponCooldown(1.0f);

            Assert.That(cooldown.TryFire(), Is.True);
            Assert.That(cooldown.TryFire(), Is.False);

            cooldown.Tick(0.99f);
            Assert.That(cooldown.TryFire(), Is.False);

            cooldown.Tick(0.01f);
            Assert.That(cooldown.TryFire(), Is.True);
        }

        [Test]
        public void WeaponCooldown_RejectsInvalidValues()
        {
            Assert.That(() => new WeaponCooldown(0f), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => new WeaponCooldown(1f).Tick(-0.1f), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DamageModel_AppliesShieldThenHull_AndClampsHull()
        {
            var model = new DamageModel(shield: 100, hull: 50);

            model.ApplyDamage(120);

            Assert.That(model.Shield, Is.EqualTo(0));
            Assert.That(model.Hull, Is.EqualTo(30));

            model.ApplyDamage(999);
            Assert.That(model.Hull, Is.EqualTo(0));
        }

        [Test]
        public void DamageModel_RejectsInvalidValues()
        {
            Assert.That(() => new DamageModel(shield: -1, hull: 10), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => new DamageModel(shield: 0, hull: 0), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => new DamageModel(shield: 10, hull: 10).ApplyDamage(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void UpgradeInventory_PurchaseRequiresEnoughCredits_AndPreventsDuplicate()
        {
            var inventory = new UpgradeInventory(startingCredits: 100);

            Assert.That(inventory.TryPurchase("engine_mk1", 120), Is.False);
            Assert.That(inventory.TryPurchase("engine_mk1", 80), Is.True);
            Assert.That(inventory.TryPurchase("engine_mk1", 80), Is.False);
            Assert.That(inventory.Credits, Is.EqualTo(20));
        }

        [Test]
        public void UpgradeInventory_RejectsInvalidInput()
        {
            Assert.That(() => new UpgradeInventory(startingCredits: -1), Throws.TypeOf<ArgumentOutOfRangeException>());

            var inventory = new UpgradeInventory(startingCredits: 100);
            Assert.That(() => inventory.TryPurchase("", 10), Throws.TypeOf<ArgumentException>());
            Assert.That(() => inventory.TryPurchase("cooldown_mk1", -5), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
