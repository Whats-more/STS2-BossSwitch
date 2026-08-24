using BaseLib.Config;

namespace BossSwitch;

internal class BossSwitchConfig : SimpleModConfig
{
    [ConfigSlider(0, 100, 5, Format = "{0}%")]
    public static int ChanceToAppear { get; set; } = 35;
}