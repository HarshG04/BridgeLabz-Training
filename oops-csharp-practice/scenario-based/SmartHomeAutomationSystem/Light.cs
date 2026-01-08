namespace SmartHomeAutomationSystem
{
    class Light : Appliances
    {

        public Light(string name)
        {
            base.ApplianceName = name;
            base.IsTurnOn = true;
        }
        public override void TurnOff()
        {
            if (IsTurnOn)
            {
                IsTurnOn = false;
                Console.WriteLine("Turning Light Off...");
            }
            else
            {
                Console.WriteLine("Light is Already Off");
            }
        }

        public override void TurnOn()
        {
             if (!IsTurnOn)
            {
                IsTurnOn = true;
                Console.WriteLine("Turning Light On...");
            }
            else
            {
                Console.WriteLine("Light is Already On");
            }
        }
    }
}