using System;
class EarthRadius {
  static void Main() {
      
       int radiusInKM = 6378;
       double volumeInKm = (4.0/3.0)*Math.PI*radiusInKM*radiusInKM*radiusInKM;
       
       double radiusInMiles = (radiusInKM/1.6);
       double volumeInMiles = (4.0/3.0)*Math.PI*radiusInMiles*radiusInMiles*radiusInMiles;
       
       Console.WriteLine("The volume of earth in cubic kilometers is " + volumeInKm + " and cubic miles is " + volumeInMiles);
    }
}