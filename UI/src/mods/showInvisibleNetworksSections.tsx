import { bindValue, trigger, useValue } from "cs2/api";
import { ModuleRegistryExtend } from "cs2/modding";
import { VanillaComponentResolver } from "./VanillaComponentResolver/VanillaComponentResolver";
import mod from "../../mod.json";

const invisibleNetworksVisible$ = bindValue<boolean>(mod.id, "InvisibleNetworksVisible");
const iconSrc = "coui://uil/Standard/DottedLinesMarkers.svg";

export const ShowInvisibleNetworksComponent: ModuleRegistryExtend = (Component: any) => {
  return (props: any) => {
    const result: JSX.Element = Component(props);
    const visible = useValue(invisibleNetworksVisible$) as boolean;

    result.props.children?.push(
      <VanillaComponentResolver.instance.Section title="Show Invisible Networks">
        <VanillaComponentResolver.instance.ToolButton
          className={VanillaComponentResolver.instance.toolButtonTheme.button}
          selected={visible}
          tooltip={visible ? "Hide invisible networks and markers" : "Show invisible networks and markers"}
          onSelect={() => trigger(mod.id, "ToggleInvisibleNetworks")}
          focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
          src={iconSrc}
        />
      </VanillaComponentResolver.instance.Section>,
    );

    return result;
  };
};
