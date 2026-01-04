using System;

public class Device
{
    public string deviceId;
    public string status;
    public virtual void DisplayStatus()
    {
        Console.WriteLine($"DeviceId: {deviceId}, Status: {status}");
    }
}

public class Thermostat : Device
{
    public double temperatureSetting;
    public override void DisplayStatus()
    {
        Console.WriteLine($"DeviceId: {deviceId}, Status: {status}, TemperatureSetting: {temperatureSetting}");
    }
}

public class Program
{
    public static void Main()
    {
        Thermostat thermostat = new Thermostat { deviceId = "T100", status = "On", temperatureSetting = 22.5 };
        thermostat.DisplayStatus();
    }
}
