# Exploratory Game (Unity MVP Bootstrap)

This repository is initialized for a **spec-first Unity MVP** focused on a single-sector PvE prototype inspired by classic space-combat browser games.

## Current Scope (Phase 1)
- 1 sector
- 2 factions (presentation only)
- 1 ship class
- PvE only
- Desktop target

## Development Approach
We use **tests as executable specification**:
1. Define player-visible behavior in feature specs.
2. Encode acceptance criteria in EditMode tests.
3. Implement gameplay code until tests pass.
4. Validate combat feel via short manual playtest charters.

See `docs/spec-workflow.md` for the complete loop.

## Project Layout
- `Assets/Scripts`: runtime gameplay logic.
- `Assets/Tests/EditMode`: executable spec tests.
- `Assets/Scripts/ExploratoryGame.Runtime.asmdef`: runtime assembly.
- `Assets/Tests/EditMode/ExploratoryGame.EditModeTests.asmdef`: EditMode test assembly.

## Suggested Local Setup
1. Install Unity Hub + Unity LTS (URP template).
2. Open this repository as a Unity project.
3. Let Unity generate project files and package lock files.
4. Run EditMode tests from the Test Runner.

## Initial Spec Targets
- Ship movement constraints
- Weapon cooldown + hit resolution
- Mission kill objective completion
- Reward grants exactly once
- Upgrade purchase rules
- Input validation for deterministic behavior

Details live in `docs/feature-specs.md`.
