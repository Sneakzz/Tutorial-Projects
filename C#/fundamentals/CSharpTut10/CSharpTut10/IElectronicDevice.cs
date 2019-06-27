
namespace CSharpTut10
{
    // With interfaces you can create very flexible systems.
    // Here we model generic electronic devices like TVs, Radios,
    // remotes that control them and the buttons on the remotes.
    interface IElectronicDevice
    {
        // We want each device to have these capabilities
        void On();
        void Off();
        void VolumeUp();
        void VolumeDown();
    }
}
