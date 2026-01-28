namespace HealthCheckPro
{
    public class LabTestController
    {
        [PublicAPI("Get all lab tests")]
        public void GetTests() { }

        [RequiresAuth("Admin")]
        public void AddTest() { }

        public void DeleteTest() { }
    }
}
