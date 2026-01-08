
namespace SmartHomeAutomationSystem
{

    abstract class Appliances : IControllable
    {
        public string ApplianceName{get;set;}
        public bool IsTurnOn{get;set;}


        public abstract void TurnOff();

        public abstract void TurnOn();

        public override string ToString()
        {
            return $"Name: {ApplianceName} || Is Turn On: {IsTurnOn}";
        }
    }
}