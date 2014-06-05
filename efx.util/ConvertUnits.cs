using Drawing;
using System;
using System.Collections.Generic;

namespace efx
{
	public class LineUtil
	{
		public double Length(HPoint p1)
		{
			return Math.Sqrt(Math.Pow(p1.X,2)+Math.Pow(p1.Y,2));
		}
	}
	public class ConvertUnits
	{
		static public double MetersToFeet(int met)
		{
			return 0d;
		}
		static public double FeetToMeters(int met)
		{
			return 0d;
		}
		//http://eosweb.larc.nasa.gov/EDDOCS/Wavelength_Program.html
		public const double met_to_feet = 3.28d; // meters to feet
		public const double spd_of_ligh = 299792458; // meters per second
		public enum band { am,fm }
		public enum units { feet }
		static public double WaveLengthFromFrequency(double freq , band tp)
		{
			// IF units = "feet" [Note: units are, by default, in meters]
			//THEN
    		//wavelength = wavelength x METERS TO FEET
			double output = 0d;
			switch (tp)
			{
				case band.am: output = spd_of_ligh/freq; break;
				case band.fm: output = spd_of_ligh*(1000/freq); break;
			}
			return output;
		}
	}
}