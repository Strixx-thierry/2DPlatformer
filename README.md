# 2D Platformer

A small 2D platformer built in **Unity 6.3 LTS (6000.3.2f1)**. The assignment was to fix the
deliberately broken/incomplete scripts in an inherited project and add features: run, jump, shoot,
collect coins, survive enemies and water, beat the boss — across a Menu → Game → Win/Lose flow.

## Controls
| Action | Key |
|--------|-----|
| Move   | `A` / `D` or `←` / `→` |
| Jump   | `Space` (only when grounded) |
| Shoot  | `J` |

## Scenes
`Start Game UI` (menu) → `GameScene-ALU` (gameplay) → `EndScene` (game over) / `Winscene` (victory).

## How to run
1. **Clone** this repository.
2. Open the **`2DPlatformer`** folder with **Unity 6.3 LTS (6000.3.2f1)** via Unity Hub.
3. If input doesn't work on first open: **Project Settings → Player → Active Input Handling → Both**.
4. Open the **`Start Game UI`** scene (`Assets/Scenes/Start Game UI.unity`) and press **Play**.
   *(Or just Build & Run — the menu scene loads first.)*

## Features
- Fixed movement, jump (grounded check), camera follow, and scene loading bugs.
- **GameManager** respawns the player at the **nearest checkpoint** when they fall in water.
- Countdown **timer**, **Start menu** (with settings panel), **End** and **Win** scenes.
- Enemies, a boss fought with the shooting mechanic, and HUD for lives/coins/time.

## Documentation
See Documentation file for the full breakdown of every bug, fix, and feature
(problem → fix → why), plus key takeaways. All code changes are marked inline with `// FIX:` / `// FEATURE:` comments.
