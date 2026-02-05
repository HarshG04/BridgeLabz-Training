using System;

namespace OceanFleet
{
    public class VesselUtil
    {
        private List<Vessel> vesselList;

        public VesselUtil()
        {
            vesselList = new List<Vessel>();
        }

        // Add Vessel To The List
        public void AddVesselPerformance(Vessel vessel)
        {
            vesselList.Add(vessel);
        }

        // Search vessel by ID
        public Vessel GetVesselById(string vesselId)
        {
            foreach (Vessel vessel in vesselList)
            {
                if (vessel.VesselId == vesselId)
                {
                    return vessel;
                }
            }
            return null;
        }

        // Get high performance vessels
        public List<Vessel> GetHighPerformanceVessels()
        {
            List<Vessel> result = new List<Vessel>();

            if (vesselList.Count == 0)
            {
                return result;
            }

            double maxSpeed = vesselList[0].AverageSpeed;

            foreach (Vessel vessel in vesselList)
            {
                if (vessel.AverageSpeed > maxSpeed)
                {
                    maxSpeed = vessel.AverageSpeed;
                }
            }

            foreach (Vessel vessel in vesselList)
            {
                if (vessel.AverageSpeed == maxSpeed)
                {
                    result.Add(vessel);
                }
            }

            return result;
        }
    }
}