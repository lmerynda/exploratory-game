# Spec-First Workflow (Executable Design)

## Goal
Move quickly with clear collaboration by treating tests as the implementation contract.

## Loop Per Feature
1. Write feature intent and acceptance scenarios.
2. Create/adjust failing EditMode tests.
3. Implement smallest code change to pass tests.
4. Run a short manual feel check in the playable scene.
5. Record one tuning decision.

## Test Layers
- **Executable Spec (EditMode):** deterministic rules (damage, cooldowns, mission state, rewards).
- **Smoke Integration (PlayMode):** minimal scene-spawn/mission-complete checks.
- **Manual Feel Checks:** camera/readability/feedback quality.

## Definition of Done
A feature is done when:
- Acceptance tests pass.
- No contradictory behavior in benchmark mission.
- One short playtest note is captured.

## Cadence
- Monday: choose 2-4 feature specs.
- Tuesday-Thursday: implement by passing tests.
- Friday: stabilization, manual benchmark runs, retune values.
