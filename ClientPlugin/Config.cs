using ClientPlugin.Settings;
using ClientPlugin.Settings.Elements;
using Sandbox.Graphics.GUI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ClientPlugin.Settings.Tools;
using VRage.Input;
using VRageMath;


namespace ClientPlugin;

public enum ExampleEnum
{
    FirstAlpha,
    SecondBeta,
    ThirdGamma,
    AndTheDelta,
    Epsilon
}

public class Config : INotifyPropertyChanged
{
    #region Options

    // TODO: Define your configuration options and their default values
    private bool enabled = true;

    #endregion

    #region User interface

    // TODO: Settings dialog title
    public readonly string Title = "Particle Obliterator Config";
        
    // TODO: Settings dialog controls, one property for each configuration option

    [Checkbox(description: "If true, all particles will be killed.")]
    public bool Enable
    {
        get => enabled;
        set => SetField(ref enabled, value);
    }


    #endregion

    #region Property change notification boilerplate

    public static readonly Config Default = new Config();
    public static readonly Config Current = ConfigStorage.Load();

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion
}