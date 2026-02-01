namespace EventTracker
{
    public class UserActionController
    {
        [AuditTrail("User Login")]
        public void Login() { }

        [AuditTrail("File Upload")]
        public void UploadFile() { }

        [AuditTrail("File Delete")]
        public void DeleteFile() { }

        public void ViewDashboard() { } // Not audited
    }
}
