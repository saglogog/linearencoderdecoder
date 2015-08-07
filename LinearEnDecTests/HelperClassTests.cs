using System;
using NUnit.Framework;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class HelperClassTests
	{
		[Test ()]
		public void TestConvertRectangulartoJaggedLtoA (){
			int[][] jagged;
			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			int[,] rectangular = PropertyClass.PArray;
				
			HelperClass hc = new HelperClass ();
			jagged = hc.ConvertRectangulartoJaggedLtoA (rectangular);

			for (int i = 0; i < jagged.GetLength (0); i++) {
				for (int j = 0; j < rectangular.GetLength (1); j++) {
					Console.Write (jagged [i] [j]);
					if (j == rectangular.GetLength (1) - 1) {
						Console.Write ("\n");
					}
				}
			}
		}

		[Test ()]
		public void TestConvertRectangulartoJaggedCtoA (){
			int[][] jagged;
			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			int[,] rectangular = PropertyClass.PArray;

			HelperClass hc = new HelperClass ();
			jagged = hc.ConvertRectangulartoJaggedCtoA (rectangular);

			for (int i = 0; i < jagged.GetLength (0); i++) {
				for (int j = 0; j < rectangular.GetLength (0); j++) {
					Console.Write (jagged [i] [j]);
					if (j == rectangular.GetLength (0) - 1) {
						Console.Write ("\n");
					}
				}
			}
		}
	}
}

