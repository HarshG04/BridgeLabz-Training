using System;

namespace OceanFleet
{
    public class Vessel
    {
        // private Variables
        private string vesselId;
        private string vesselName;
        private double averageSpeed;
        private string vesselType;

        public Vessel(){ }

        public Vessel(string vesselId, string vesselName, double averageSpeed, string vesselType)
        {
            this.vesselId = vesselId;
            this.vesselName = vesselName;
            this.averageSpeed = averageSpeed;
            this.vesselType = vesselType;
        }

        // Properties (Getters and Setters)
        public string VesselId
        {
            get { return vesselId; }
            set { vesselId = value; }
        }

        public string VesselName
        {
            get { return vesselName; }
            set { vesselName = value; }
        }

        public double AverageSpeed
        {
            get { return averageSpeed; }
            set { averageSpeed = value; }
        }

        public string VesselType
        {
            get { return vesselType; }
            set { vesselType = value; }
        }
    }
}