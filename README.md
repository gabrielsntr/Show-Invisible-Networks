# Show Invisible Networks

A Cities: Skylines II code/UI mod that lets you toggle visibility for invisible networks and markers.

The mod uses the game's built-in `Game.Rendering.RenderingSystem.markersVisible` flag. It does not draw custom overlays or patch network rendering. When enabled, it reveals all marker-backed invisible networks and markers, including those created by Extra Networks and Areas.

## Motivation

Invisible paths are useful for custom layouts, but they can be hard to work with once placed. This mod was made for cases where you want to add a surface, area, or other detail around an invisible path and need to see exactly where that path is.

## Features

- Rebindable hotkey, defaulting to `Ctrl+M`.
- Options menu toggle.
- Tool options panel button.
- Persistent setting shared by all three controls.
- Reasserts marker visibility while enabled so other tools do not silently turn it off.
- Stops forcing the flag after disabling so normal tool behavior can resume.

## Requirement

- [Extra Networks and Areas](https://mods.paradoxplaza.com/mods/77175/Windows)
- [Unified Icon Library](https://mods.paradoxplaza.com/mods/74417/Windows)

The Paradox dependencies are declared in `Properties/PublishConfiguration.xml`. Extra Networks and Areas uses id `77175`; Unified Icon Library uses id `74417`.

## Known Behavior

This mod intentionally toggles the global CSII marker visibility flag. That means it can reveal more than Extra Networks and Areas paths, including vanilla markers, spawners, points, and other marker entities.

## Build

Requirements:

- Cities: Skylines II modding toolchain installed through the game.
- .NET SDK 8.
- .NET Runtime 6, required by the CSII mod post-processor.
- Node.js and npm for the UI bundle.

Build the C# mod:

```powershell
dotnet build ShowInvisibleNetworks.csproj
```

Build the UI module:

```powershell
cd UI
npm install
npm run build
```

The build output deploys to the local CSII mods folder:

```text
%LOCALAPPDATA%Low\Colossal Order\Cities Skylines II\Mods\ShowInvisibleNetworks
```

## In-Game Test

1. Enable the mod in Cities: Skylines II.
2. Load a save or editor session.
3. Press `Ctrl+M`, use the Options toggle, or click the tool panel button.
4. Confirm invisible networks and markers become visible.
5. Toggle it off and confirm the mod stops forcing marker visibility.

Logs are written under:

```text
%LOCALAPPDATA%Low\Colossal Order\Cities Skylines II\Logs
```

## Credits

The implementation follows the same core marker visibility mechanism used by Better Bulldozer.
