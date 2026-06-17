import { ModRegistrar } from "cs2/modding";
import { ShowInvisibleNetworksComponent } from "mods/showInvisibleNetworksSections";
import { VanillaComponentResolver } from "mods/VanillaComponentResolver/VanillaComponentResolver";
import mod from "../mod.json";

const register: ModRegistrar = (moduleRegistry) => {
  VanillaComponentResolver.setRegistry(moduleRegistry);

  moduleRegistry.extend(
    "game-ui/game/components/tool-options/mouse-tool-options/mouse-tool-options.tsx",
    "MouseToolOptions",
    ShowInvisibleNetworksComponent,
  );

  console.log(`${mod.id} UI module registrations completed.`);
};

export default register;
