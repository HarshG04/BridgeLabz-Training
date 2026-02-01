using System;

namespace EventTracker
{
    public interface IAuditScanner
    {
        void ScanAndGenerateLogs(Type classType);
    }
}
