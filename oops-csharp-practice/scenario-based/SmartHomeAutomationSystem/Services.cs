namespace SmartHomeAutomationSystem
{
    class Services
    {
        Appliances fan = new Fan("Room Fan");
        Appliances light = new Light("Room Light");
        Appliances ac = new AC("Room AC");

        public void TurnFanOn()
        {
            fan.TurnOn();
        }
        public void TurnFanOff()
        {
            fan.TurnOff();
        }
        public void TurnLightOn()
        {
            light.TurnOn();
        }
        public void TurnLightOff()
        {
            light.TurnOff();
        }
        public void TurnACOn()
        {
            ac.TurnOn();
        }
        public void TurnACOff()
        {
            ac.TurnOff();
        }

    }
}