using System;

namespace HealthCheckPro
{
    public interface IHealthCheck
    {
        void ScanController(Type type);
    }
}
