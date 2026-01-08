namespace SmartHomeAutomationSystem
{
    class Fan : Appliances
    {
        public Fan(string name)
        {
            base.ApplianceName = name;
            base.IsTurnOn = true;
        }

        public override void TurnOff()
        {
            if (IsTurnOn)
            {
                IsTurnOn = false;
                Console.WriteLine("Turning Fan Off...");
            }
            else
            {
                Console.WriteLine("Fan is Already Off");
            }
        }

        public override void TurnOn()
        {
             if (!IsTurnOn)
            {
                IsTurnOn = true;
                Console.WriteLine("Turning Fan On...");
            }
            else
            {
                Console.WriteLine("Fan is Already On");
            }
        }
    }
}