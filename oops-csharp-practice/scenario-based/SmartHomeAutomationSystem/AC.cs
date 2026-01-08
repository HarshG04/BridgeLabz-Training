namespace SmartHomeAutomationSystem
{
    class AC : Appliances
    {

        public AC(string name)
        {
            base.ApplianceName = name;
            base.IsTurnOn = true;
        }


        public override void TurnOff()
        {
            if (IsTurnOn)
            {
                IsTurnOn = false;
                Console.WriteLine("Turning AC Off...");
            }
            else
            {
                Console.WriteLine("AC is Already Off");
            }
        }

        public override void TurnOn()
        {
             if (!IsTurnOn)
            {
                IsTurnOn = true;
                Console.WriteLine("Turning AC On...");
            }
            else
            {
                Console.WriteLine("AC is Already On");
            }
        }
    }
}