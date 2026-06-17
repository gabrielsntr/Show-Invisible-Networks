declare module "cs2/api" {
  export type Binding<T> = unknown;
  export function bindValue<T>(group: string, name: string): Binding<T>;
  export function useValue<T>(binding: Binding<T>): T;
  export function trigger(group: string, name: string, ...args: unknown[]): void;
}

declare module "cs2/bindings" {
  export type FocusKey = unknown;
  export type Theme = any;
  export type UniqueFocusKey = unknown;
}

declare module "cs2/modding" {
  export type ModuleRegistry = {
    registry: Map<string, any>;
    extend: (path: string, exportName: string, extension: ModuleRegistryExtend) => void;
  };

  export type ModuleRegistryExtend = (component: any) => any;
  export type ModRegistrar = (moduleRegistry: ModuleRegistry) => void;

  export function getModule(path: string, exportName: string): any;
}
