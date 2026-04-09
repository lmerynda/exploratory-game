# Initial Executable Feature Specs

## 1) Mission Kill Objective v1
**Intent:** player completes mission by defeating required enemies.

### Acceptance
- Given required kills = 5, when player has 4 kills, mission remains Active.
- Given required kills = 5, when player reaches 5 kills, mission becomes Success.
- Rewards are granted once even if completion event fires repeatedly.
- Mission constructor rejects non-positive required kill counts.

### Out of Scope
- Multi-stage objectives
- Time-based bonus rewards

## 2) Weapon Cooldown v1
**Intent:** primary weapon cannot fire while cooling down.

### Acceptance
- Fire succeeds if cooldown timer is ready.
- Fire fails if cooldown remaining > 0.
- Cooldown reaches ready after elapsed time >= cooldown duration.
- Constructor rejects non-positive cooldown values.
- Tick rejects negative delta time.

## 3) Upgrade Purchase v1
**Intent:** player can buy upgrade only with enough credits and only once.

### Acceptance
- Purchase fails when credits < price.
- Purchase succeeds when credits >= price.
- Duplicate purchase fails after upgrade already owned.
- Constructor rejects negative starting credits.
- Purchase rejects empty upgrade IDs and negative prices.

## 4) Damage Resolution v1
**Intent:** incoming damage applies to shields first, then hull.

### Acceptance
- Shield absorbs damage up to available amount.
- Overflow damage reduces hull by remainder.
- Hull never drops below zero.
- Constructor rejects negative shield and non-positive hull.
- ApplyDamage rejects negative damage values.
