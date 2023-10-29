using MSteer;
using MSteerHelp;
using System;
using System.Windows;
using System.Windows.Controls;
using Windows.Devices.Adc;

public partial class MainWindow : Window
{
    ABSController absController = ABSController.Instance;

    public MainWindow()
    {
        InitializeComponent();
        // Остальной код
    }

    private void OnToggleABSButtonChecked(object sender, RoutedEventArgs e)
    {
        absController.ActivateABS();
        ToggleABSButton.Content = "ON";
    }

    private void OnToggleABSButtonUnchecked(object sender, RoutedEventArgs e)
    {
        absController.DeactivateABS();
        ToggleABSButton.Content = "OFF";
    }


    private void MouseSensitivitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        MouseSteering.MouseSensitivity = (int)MouseSensitivitySlider.Value;

    }
    private void GyroSensitivitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        MouseSteering.GyroSensitivity = (int)GyroSensitivitySlider.Value;

    }
    private void FfbSensitivitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        MouseSteering.FFBSensitivity = (int)FfbSensitivitySlider.Value;
    }
}
