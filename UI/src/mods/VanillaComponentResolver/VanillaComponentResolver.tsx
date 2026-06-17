import { FocusKey, Theme, UniqueFocusKey } from "cs2/bindings";
import { ModuleRegistry } from "cs2/modding";
import { HTMLAttributes, ReactNode } from "react";

type PropsToolButton = {
  focusKey?: UniqueFocusKey | null;
  src: string;
  selected?: boolean;
  multiSelect?: boolean;
  disabled?: boolean;
  tooltip?: string | ReactNode | null;
  selectSound?: unknown;
  uiTag?: string;
  className?: string;
  children?: string | JSX.Element | JSX.Element[];
  onSelect?: (x: unknown) => unknown;
} & HTMLAttributes<unknown>;

type PropsSection = {
  title?: string | null;
  uiTag?: string;
  children: string | JSX.Element | JSX.Element[];
};

const registryIndex = {
  Section: ["game-ui/game/components/tool-options/mouse-tool-options/mouse-tool-options.tsx", "Section"],
  ToolButton: ["game-ui/game/components/tool-options/tool-button/tool-button.tsx", "ToolButton"],
  toolButtonTheme: ["game-ui/game/components/tool-options/tool-button/tool-button.module.scss", "classes"],
  FOCUS_DISABLED: ["game-ui/common/focus/focus-key.ts", "FOCUS_DISABLED"],
  FOCUS_AUTO: ["game-ui/common/focus/focus-key.ts", "FOCUS_AUTO"],
  useUniqueFocusKey: ["game-ui/common/focus/focus-key.ts", "useUniqueFocusKey"],
};

export class VanillaComponentResolver {
  public static get instance(): VanillaComponentResolver {
    return this._instance!;
  }

  private static _instance?: VanillaComponentResolver;

  public static setRegistry(registry: ModuleRegistry): void {
    this._instance = new VanillaComponentResolver(registry);
  }

  private cachedData: Partial<Record<keyof typeof registryIndex, unknown>> = {};

  private constructor(private readonly registryData: ModuleRegistry) {
  }

  private updateCache(entry: keyof typeof registryIndex): unknown {
    const entryData = registryIndex[entry];
    this.cachedData[entry] = this.registryData.registry.get(entryData[0])![entryData[1]];
    return this.cachedData[entry];
  }

  public get Section(): (props: PropsSection) => JSX.Element {
    return (this.cachedData.Section ?? this.updateCache("Section")) as (props: PropsSection) => JSX.Element;
  }

  public get ToolButton(): (props: PropsToolButton) => JSX.Element {
    return (this.cachedData.ToolButton ?? this.updateCache("ToolButton")) as (props: PropsToolButton) => JSX.Element;
  }

  public get toolButtonTheme(): Theme | any {
    return this.cachedData.toolButtonTheme ?? this.updateCache("toolButtonTheme");
  }

  public get FOCUS_DISABLED(): UniqueFocusKey {
    return (this.cachedData.FOCUS_DISABLED ?? this.updateCache("FOCUS_DISABLED")) as UniqueFocusKey;
  }

  public get FOCUS_AUTO(): UniqueFocusKey {
    return (this.cachedData.FOCUS_AUTO ?? this.updateCache("FOCUS_AUTO")) as UniqueFocusKey;
  }

  public get useUniqueFocusKey(): (focusKey: FocusKey, debugName: string) => UniqueFocusKey | null {
    return (this.cachedData.useUniqueFocusKey ?? this.updateCache("useUniqueFocusKey")) as (focusKey: FocusKey, debugName: string) => UniqueFocusKey | null;
  }
}
